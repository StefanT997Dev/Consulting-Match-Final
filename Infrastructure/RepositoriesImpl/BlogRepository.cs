using Application.Interfaces.Repositories.Blogs;
using Domain;
using Persistence.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesImpl
{
	public class BlogRepository : IBlogRepository
	{
		private readonly IDbContext _context;

		public BlogRepository(IDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Blog input)
		{
			await _context.Blogs.InsertOneAsync(input);
		}


		public Task<IEnumerable<Blog>> FindAsync(Expression<Func<Blog, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Blog>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Blog> GetAsync(Expression<Func<Blog, bool>> expression)
		{
			throw new NotImplementedException();
		}
	}
}
