using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.Mentorship;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mentorships
{
    public class ClientsMentorDetails
    {
		public record Query() : IRequest<Result<ClientsMentorDto>>;

		public class Handler : IRequestHandler<Query, Result<ClientsMentorDto>>
		{
            private readonly IMentorshipRepository _mentorshipRepository;
            private readonly IUserAccessor _userAccessor;

            public Handler(IMentorshipRepository mentorshipRepository, IUserAccessor userAccessor)
			{
                _mentorshipRepository = mentorshipRepository;
                _userAccessor = userAccessor;
            }

			public async Task<Result<ClientsMentorDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				// izvuci trenutnog user-a sa IUserAccessorom.
				_userAccessor.GetUsername();
				// za tog user-a izvuci podatke iz mentorship-a.

				var result = await _mentorshipRepository.GetAsync<ClientsMentorDto>(x => x.ClientId == "ssd", y => true);

				if (Equals(result, null))
				{
					return Result<ClientsMentorDto>.Failure("Message");
				}
				return Result<ClientsMentorDto>.Success(result);
			}
		}
	}
}
