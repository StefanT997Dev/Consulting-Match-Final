using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Packages;

namespace API.Controllers
{
	public class PackagesController : BaseApiController
	{
		[HttpPost]
		public async Task<IActionResult> Add(PackageDto package)
		{
			return HandleResult(await Mediator.Send(new Create.Command { Package=package}));
		}
	}
}
