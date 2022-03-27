using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Mentors
{
	public class Details
    {
        public class Query : IRequest<Result<MentorDisplayDto>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MentorDisplayDto>>
        {
			private readonly IMentorsRepository _mentorsRepository;

			public Handler(IMentorsRepository mentorsRepository)
            {
				_mentorsRepository = mentorsRepository;
			}

            public async Task<Result<MentorDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _mentorsRepository.GetMentorAsync<MentorDisplayDto>(request.Id);
                 
                if (user == null)
                {
                    return Result<MentorDisplayDto>.Failure("Nismo uspeli da pronađemo željenog korisnika, potencijalni problem: Korisnik nema ulogu mentora");
                }

                return Result<MentorDisplayDto>.Success(user);
            }
        }
    }
}