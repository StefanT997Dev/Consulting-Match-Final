using System.Threading.Tasks;
using Application.DTOs;
using Application.Followers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FollowController:BaseApiController
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Follow(TargetUserDto targetUser)
        {
            return Ok(await Mediator.Send(new FollowToggle.Command{TargetUser=targetUser}));
        }
        [AllowAnonymous]
        [HttpGet("{targetUserId}")]
        public async Task<IActionResult> GetStats(string targetUserId)
        {
            return HandleResult(await Mediator.Send(new Details.Query{UserId=targetUserId}));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{targetUserId}/check")]
        public async Task<IActionResult> GetStatOnWhetherTheUserIsFollowed(string targetUserId)
        {
            return HandleResult(await Mediator.Send(new IsFollowed.Query{TargetUserId=targetUserId}));
        }
        [AllowAnonymous]
        [HttpGet("dashboard/{targetUserId}")]
        public async Task<IActionResult> GetListOfFollowersAndFollowing(string targetUserId)
        {
            return HandleResult(await Mediator.Send(new Dashboard.Query{TargetUserId=targetUserId}));
        }
    }
}