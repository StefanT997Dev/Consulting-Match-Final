﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;

namespace Application.Interfaces.Repositories.Mentors
{
	public interface IMentorsRepository: IRepository<AppUser, string>
	{
		Task<Tuple<IEnumerable<MentorDisplayDto>, int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category);
	}
}
