using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Categories;
using Application.DTOs;
using Domain;
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id=id}));
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            return Ok(await Mediator.Send(new Create.Command{Category=category}));
        }

        [AllowAnonymous]
        [HttpGet("{id}/consultants")]
        public async Task<IActionResult> GetConsultantsForCategory(Guid id)
        {
            return HandleResultForCollections(await Mediator.Send(new ListOfConsultants.Query{Id=id}));
        }

        [AllowAnonymous]
        [HttpPost("choose")]
        public async Task<IActionResult> PickACategoryForConsultant(AppUserCategoryDto appUserCategory)
        {
            return Ok(await Mediator.Send(new Pick.Command{AppUserCategory=appUserCategory}));
        }
    }
}