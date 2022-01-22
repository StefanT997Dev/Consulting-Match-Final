using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
		private readonly DataContext _context;

		public AccountController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            TokenService tokenService,
            DataContext context)
        {
            _tokenService = tokenService;
			_context = context;
			_signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            user.Role = await _context.Roles.FirstOrDefaultAsync(x => x.Users.Contains(user));

            if (user.Role == null)
            {
                return BadRequest("Nismo uspeli da pronađemo ulogu korisnika");
            }

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user),
                    Username = user.UserName,
                    Image = "Some image",
                    Video = user.SalesVideo,
                    Role = user.Role.Name
                };
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email je zauzet");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Korisničko ime je zauzeto");
            }

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == registerDto.RoleName);

            if (role == null)
            {
                return BadRequest("Nismo uspeli da pronađemo izabranu ulogu");
            }

            if (registerDto.RoleName == "Mentor")
            {
                role.Name = "Potential Mentor";
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Username,
                RoleId = role.Id,
                Role = role
            };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
				try
				{
                    var result = await _userManager.CreateAsync(user, registerDto.Password);

                    UserDto userDto = null;

                    if (result.Succeeded)
                    {
                        userDto = new UserDto
                        {
                            Id = user.Id,
                            DisplayName = user.DisplayName,
                            Image = null,
                            Token = _tokenService.CreateToken(user),
                            Username = user.UserName,
                            Role = role.Name
                        };
                    }

                    await transaction.CommitAsync();

                    return userDto;
                }
				catch (System.Exception)
				{
                    await transaction.RollbackAsync();
				}
            } 

            return BadRequest("Problem pri registraciji korisnika");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }
    }
}