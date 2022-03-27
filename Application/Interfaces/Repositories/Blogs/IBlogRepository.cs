using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Blogs
{
	public interface IBlogRepository
	{
		Task<Blog> GetAsync(Expression<Func<Blog, bool>> expression);
		Task<IEnumerable<Blog>> GetAllAsync();
		Task<IEnumerable<Blog>> FindAsync(Expression<Func<Blog, bool>> expression);
		Task AddAsync(Blog input);
	}
}
