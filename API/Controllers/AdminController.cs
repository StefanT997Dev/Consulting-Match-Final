using System.Threading.Tasks;
using API.DTOs;
using Application.Roles;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController:BaseApiController
    {
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Add(RoleDto role)
        {
            return Ok(await Mediator.Send(new Create.Command{RoleName=role.Name}));
        }

        [HttpDelete]
        //[Authorize(Roles="Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUser(UserEmailDto userEmailDto)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{UserEmail=userEmailDto.Email}));
        }
    }
}