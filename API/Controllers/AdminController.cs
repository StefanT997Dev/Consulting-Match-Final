using System.Security.Claims;
using System.Threading.Tasks;
using API.Attributes;
using API.DTOs;
using Application.Admin;
using Application.DTOs;
using Application.Roles;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController:BaseApiController
    {
        [HttpPost]
        [ClaimRequirement(ClaimTypes.Role,"Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(Application.DTOs.RoleDto role)
        {
            return Ok(await Mediator.Send(new Create.Command{RoleName=role.Name}));
        }

        [HttpDelete]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(UserEmailDto userEmailDto)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{UserEmail=userEmailDto.Email}));
        }

        [HttpPatch]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateMento(AdminUpdateMentorDto updateMentorDto)
        {
            return HandleResult(await Mediator.Send(new UpdateMentor.Command { UpdateMentorDto = updateMentorDto }));
        }
    }
}