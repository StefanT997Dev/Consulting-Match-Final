using Application.Interfaces.Repositories.Blogs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BlogController : ControllerBase
	{
		private readonly IBlogRepository _blogRepository;

		public BlogController(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Add(Blog blog)
		{
			await _blogRepository.AddAsync(blog);

			return Ok("Uspešno ste dodali blog");
		}
	}
}
