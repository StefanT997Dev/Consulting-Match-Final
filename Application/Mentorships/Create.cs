using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mentorships
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public MentorshipDto Mentorship { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IUserAccessor _userAccessor;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
			{
				_context = context;
				_userAccessor = userAccessor;
				_mapper = mapper;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var client = await _context.Users
					.ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Username == _userAccessor.GetUsername());

				if (client == null)
				{ 
					return Result<Unit>.Failure("Nismo uspeli, najverovatnije niste prijavljeni na sistem, ulogujte se i pokušajte ponovo");
				}

				var mentorship = new Mentorship
				{
					ClientId = client.Id,
					MentorId = request.Mentorship.MentorId,
					NumberOfSessions = request.Mentorship.NumberOfSessions
				};

				if (await _context.Mentorships.AnyAsync(x => x.ClientId == client.Id
					&& x.MentorId == request.Mentorship.MentorId))
				{
					return Result<Unit>.Failure("Već ste u saradnji sa ovim mentorom");
				}

				_context.Mentorships.Add(mentorship);

				var result = await _context.SaveChangesAsync() > 0;

				if (result)
				{
					return Result<Unit>.Success(Unit.Value);
				}

				return Result<Unit>.Failure("Nismo uspeli da zapamtimo mentorstvo");
			}
		}
	}
}
