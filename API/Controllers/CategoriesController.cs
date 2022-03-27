using System;
using System.Threading.Tasks;
using Application.Categories;
using Application.DTOs;
using Application.Mentors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class CategoriesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return HandleResultForLists(await Mediator.Send(new List.Query()));
        }

		/*[AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id=id}));
        }*/

		/*[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            return Ok(await Mediator.Send(new Create.Command{Category=category}));
        }*/

		/*[AllowAnonymous]
        [HttpGet("{id}/mentors")]
        public async Task<IActionResult> GetMentorsForCategory(Guid id)
        {
            return HandleResultForCollections(await Mediator.Send(new ListOfMentors.Query{Id=id}));
        }
*/
        [AllowAnonymous]
		[HttpPut("choose")]
		public async Task<IActionResult> PickACategoryForMentor(AppUserCategoryDto appUserCategory)
		{
			return Ok(await Mediator.Send(new ChooseCategory.Command { AppUserCategory = appUserCategory }));
		}
	}
}