﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PhotosController:BaseApiController
	{
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Mentor")]
		[HttpPost]
		public async Task<IActionResult> Add([FromForm] Add.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}
	}
}
