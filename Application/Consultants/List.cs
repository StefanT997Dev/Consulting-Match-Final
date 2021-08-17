using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;

namespace Application.Consultants
{
    public class List
    {
        public class Query : IRequest<Result<List<ConsultantDisplayDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ConsultantDisplayDto>>>
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

            public async Task<Result<List<ConsultantDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                    .ProjectTo<ConsultantDisplayDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                foreach (var user in users)
                {
                    user.Categories = await _categoriesRepository.GetCategories(user);
                    var reviews = await _reviewsRepository.GetReviews(user.Id);

                    user.Reviews=reviews;

                    var result = Common.GetAverageReviewAndTotalStarRating(reviews);
                }

                return Result<List<ConsultantDisplayDto>>.Success(users);
            }
        }
    }
}