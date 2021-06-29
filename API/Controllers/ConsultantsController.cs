using System.Threading.Tasks;
using Application.Consultants;
using Application.DTOs;
using Application.Posts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ConsultantsController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetConsultants()
        {
            return HandleResultForLists(await Mediator.Send(new Application.Consultants.List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultant(string id)
        {
            return HandleResult(await Mediator.Send(new Application.Consultants.Details.Query{Id=id}));
        }

        [AllowAnonymous]
        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(string id)
        {
            return HandleResultForLists(await Mediator.Send(new Application.Reviews.List.Query{Id=id}));
        }
        
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Client")]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostReview([FromRoute]string id,[FromBody]ReviewDto review)
        {
            return Ok(await Mediator.Send(new Application.Reviews.Create.Command{Id=id,Review=review}));
        }

        [AllowAnonymous]
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPosts(string id)
        {
            return HandleResultForLists(await Mediator.Send(new ListForConsultant.Query{Id=id}));
        }

        [HttpPost("{id}/posts")]
        public async Task<IActionResult> PostAPost(string id,Post post)
        {
            return Ok(await Mediator.Send(new CreateAPost.Command{Id=id,Post=post}));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Search(ConsultantSearchDto consultant)
        {
            return Ok(await Mediator.Send(new Search.Command{Consultant=consultant}));
        }
    }
}