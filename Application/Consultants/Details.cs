using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Consultants
{
    public class Details
    {
        public class Query : IRequest<Result<ConsultantDisplayDto>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ConsultantDisplayDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ConsultantDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                var listOfCategoryNames = await Common.GetCategoriesForUser(_context, user);

                var listOfReviewsDtoForConsultant = await Common.GetUserReviews(_context, _mapper, user.Id);

                var result = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForConsultant);

                var consultantDisplayDto = new ConsultantDisplayDto
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Image = user.ProfilePicture,
                    Bio = user.Bio,
                    NumberOfReviews = listOfReviewsDtoForConsultant.Count,
                    AverageStarReview = result.Item2,
                    Reviews = listOfReviewsDtoForConsultant,
                    TotalStarRating = result.Item1,
                    Categories = listOfCategoryNames
                };

                return Result<ConsultantDisplayDto>.Success(consultantDisplayDto);
            }
        }
    }
}