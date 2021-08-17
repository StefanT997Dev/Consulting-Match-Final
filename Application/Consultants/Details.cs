using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            private readonly ICategoriesRepository _categoriesRepository;
            private readonly IReviewsRepository _reviewsRepository;
            public Handler(DataContext context, IMapper mapper, ICategoriesRepository categoriesRepository, IReviewsRepository reviewsRepository)
            {
                _reviewsRepository = reviewsRepository;
                _categoriesRepository = categoriesRepository;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ConsultantDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .ProjectTo<ConsultantDisplayDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(u => u.Id==request.Id);

                var listOfCategoryNames = await _categoriesRepository.GetCategories(user);

                var listOfReviewsDtoForConsultant = await _reviewsRepository.GetReviews(user.Id);

                var result = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForConsultant);

                user.Reviews=listOfReviewsDtoForConsultant;

                user.Categories=listOfCategoryNames;

                user.AverageStarReview=result.Item2;

                user.NumberOfReviews=listOfReviewsDtoForConsultant.Count;

                user.TotalStarRating=result.Item1;

                return Result<ConsultantDisplayDto>.Success(user);
            }
        }
    }
}