using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;
using Application.Interfaces.Repositories.Mentors;
using Application.Core.Wrappers;
using System;
using Domain;
using Application.Core;

namespace Application.Mentors
{
	public class PaginatedList
    {
        public class Query : IRequest<PagedResult<List<MentorDisplayDto>>> 
        {
			public FilterDto Filter { get; set; }
		}

		public class Handler : IRequestHandler<Query, PagedResult<List<MentorDisplayDto>>>
        {
			private readonly IMentorsRepository _mentorsRepository;

			public Handler(IMentorsRepository mentorsRepository)
            {
				_mentorsRepository = mentorsRepository;
			}

            public async Task<PagedResult<List<MentorDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var mentorTuple = await _mentorsRepository.GetMentorsPaginatedAsync(request.Filter.PageNumber, request.Filter.PageSize, request.Filter.Category);

                var mentorsList = mentorTuple.Item1.ToList();

                int totalRecords = mentorTuple.Item2;

                foreach (var mentor in mentorsList)
                {
                    mentor.NumberOfReviews = mentor.Reviews.Count;

                    var result = Common.GetTotalStarRatingAndAverageStarReview(mentor.Reviews);

                    mentor.TotalStarRating = result.Item1;

                    mentor.AverageStarReview = result.Item2;
                }

                int numberOfPages = CalculateNumberOfPages(request, totalRecords);

                return PagedResult<List<MentorDisplayDto>>.Success(mentorsList, numberOfPages, totalRecords);
            }

			private static int CalculateNumberOfPages(Query request, int totalRecords)
			{
                return ((totalRecords - 1) / request.Filter.PageSize) + 1;
            }
		}
    }
}