using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Profiles;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class ListOfConsultants
    {
        public class Query : IRequest<Result<ICollection<Profiles.Profile>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ICollection<Profiles.Profile>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ICollection<Profiles.Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var selectedCategory = _context.Categories
                    .Include(c => c.Consultants)
                    .ThenInclude(ac => ac.AppUser)
                    .FirstOrDefault(c => c.Id == request.Id);

                var listOfReviews = new List<Review>();

                var listOfProfiles = new List<Profiles.Profile>();

                foreach (var consultant in selectedCategory.Consultants)
                {
                    var reviews = await _context.Reviews.Where(r => r.Consultant.Id == consultant.AppUserId).ToListAsync();

                    var listOfReviewsDtoForConsultant = new List<ReviewDto>();

                    foreach (var review in reviews)
                    {
                        listOfReviewsDtoForConsultant.Add(new ReviewDto
                        {
                            StarRating = review.StarRating,
                            Comment = review.Comment
                        });

                    }

                    listOfProfiles.Add(
                    new Profiles.Profile
                    {
                        Id = consultant.AppUserId,
                        DisplayName = consultant.AppUser.DisplayName,
                        Image = consultant.AppUser.ProfilePicture,
                        Bio = consultant.AppUser.Bio,
                        NumberOfReviews = reviews.Count,
                        AverageStarReview = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForConsultant).Item2,
                        Reviews = listOfReviewsDtoForConsultant
                    });
                }

                return Result<ICollection<Profiles.Profile>>.Success(listOfProfiles);
            }
        }
    }
}