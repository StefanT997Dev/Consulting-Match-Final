using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MessageController:BaseApiController
    {
        // [HttpPost("{consultantId}")]
        // public async Task<IActionResult> Send(string consultantId,Message message)
        // {
        //     return Ok(await Mediator.Send(new Application.Messages.Send.Command{ConsultantId=consultantId,Message=message}));
        // }
    }
}