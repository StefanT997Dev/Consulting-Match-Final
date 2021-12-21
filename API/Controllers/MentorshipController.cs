﻿using Application.DTOs;
using Application.Mentorships;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class MentorshipController : BaseApiController
	{
		[HttpPost]
		public async Task<IActionResult> Add(MentorshipDto mentorship)
		{
			return HandleResult(await Mediator.Send(new Create.Command { Mentorship = mentorship }));
		}

		[HttpGet]
		public async Task<IActionResult> GetAllClientsOfMentor()
		{
			return HandleResult(await Mediator.Send(new ListOfClientsForMentor { }));
		}
	}
}
