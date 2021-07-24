using System.Threading.Tasks;
using API.DTOs;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController:BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery]FilterDto filter)
        {
            return HandleResult(await Mediator.Send(new FilteredList.Query{PageNumber=filter.PageNumber,PageSize=filter.PageSize}));
        }
    }
}