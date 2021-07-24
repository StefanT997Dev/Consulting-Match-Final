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

namespace Application.Consultants
{
    public class List
    {
        public class Query : IRequest<Result<List<ConsultantDisplayDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ConsultantDisplayDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
                _context.ChangeTracker.LazyLoadingEnabled = false;
            }

            public async Task<Result<List<ConsultantDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.ToListAsync();

                var listOfConsultantDisplayDtos = new List<ConsultantDisplayDto>();

                foreach (var user in users)
                {
                    var listOfCategoryNames = await Common.GetCategoriesForUser(_context, user);
                    var listOfReviewsDtoForConsultant = await Common.GetUserReviews(_context, _mapper, user.Id);

                    var result = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForConsultant);

                    listOfConsultantDisplayDtos.Add(
                        new ConsultantDisplayDto
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
                        }
                    );
                }

                return Result<List<ConsultantDisplayDto>>.Success(listOfConsultantDisplayDtos);
            }
        }
    }
}