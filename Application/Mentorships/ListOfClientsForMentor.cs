using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.Mentors;
using Application.Interfaces.Repositories.Mentorship;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mentorships
{
	public class ListOfClientsForMentor
	{
		public class Query : IRequest<Result<List<ClientDashboardDisplayDto>>>
		{ 
			
		}

		public class Handler : IRequestHandler<Query, Result<List<ClientDashboardDisplayDto>>>
		{
			private readonly DataContext _context;
			private readonly IMentorshipRepository _mentorshipRepository;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IMentorshipRepository mentorshipRepository,IUserAccessor userAccessor)
			{
				_context = context;
				_mentorshipRepository = mentorshipRepository;
				_userAccessor = userAccessor;
			}

			public async Task<Result<List<ClientDashboardDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var mentor = await _context.Users.FirstOrDefaultAsync(
					x => x.UserName == _userAccessor.GetUsername()
				);

				if (mentor == null)
				{
					return Result<List<ClientDashboardDisplayDto>>
						.Failure("Greška, nismo uspeli da Vas pronađemo u bazi podataka");
				}

				var listOfClients = await _mentorshipRepository
					.FindAsync<ClientDashboardDisplayDto>(x => x.MentorId == mentor.Id);

				return Result<List<ClientDashboardDisplayDto>>.
					Success(listOfClients.ToList());
			}
		}
	}
}
