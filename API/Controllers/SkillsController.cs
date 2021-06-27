using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Skills;
using Application.DTOs;

namespace API.Controllers
{
    public class SkillsController:BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Add(Guid categoryId,SkillDto skill)
        {
            return Ok(await Mediator.Send(new Create.Command{CategoryId=categoryId,Skill=skill}));
        }

        [AllowAnonymous]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetSkills(Guid categoryId)
        {
            return HandleResult(await Mediator.Send(new List.Query{CategoryId=categoryId}));
        }
    }
}