using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoriesImpl
{
	public class MentorsRepository : Repository<AppUser>, IMentorsRepository
	{

		public MentorsRepository(DataContext context, IMapper mapper): base(context, mapper)
		{
			
		}

		public async Task<Tuple<IEnumerable<MentorDisplayDto>,int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category)
		{
			int totalRecords = 0;
			var mentors = entities
				.Where(x => x.Role.Name == "Mentor" || x.Role.Name == "Potential Mentor")
				.ProjectTo<MentorDisplayDto>(mapperConfigurationProvider);

			if (category != null)
			{
				mentors.Where(m => m.Categories.Any(c => c.Name == category));
				totalRecords = await mentors.CountAsync();
			}
			else
			{
				totalRecords = await mentors.CountAsync();
			}

			return new Tuple<IEnumerable<MentorDisplayDto>, int>(await mentors
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(),totalRecords);
		}

		public async Task<bool> IsMentor(string userId)
		{
			return await entities.AnyAsync(x => x.Id == userId &&
			(x.Role.Name == "Mentor" || x.Role.Name == "Potential Mentor"));
		}
	}
}
