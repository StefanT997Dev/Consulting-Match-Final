using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Schedules;

namespace API.Controllers
{
    public class ScheduleController:BaseApiController
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> ScheduleConsultation(ScheduleDto schedule)
        {
            return Ok(await Mediator.Send(new Create.Command{Schedule=schedule}));
        }
    }
}