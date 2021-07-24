using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{
    public class Common
    {
        public async static Task<List<string>> GetCategoriesForUser(DataContext _context, AppUser user)
        {
            var appUserCategory = _context.AppUserCategories
                        .Where(ac => ac.AppUserId == user.Id)
                        .FirstOrDefault();
            
            if(appUserCategory==null)
            {
                return new List<string>(){"No category has been chosen yet"};
            }

            var categories = await _context.Categories.Where(c => c.Id == appUserCategory.CategoryId).ToListAsync();

            var listOfCategoryNames = new List<string>();

            foreach (var category in categories)
            {
                listOfCategoryNames.Add(category.Name);
            }

            return listOfCategoryNames;
        }

        public async static Task<List<ReviewDto>> GetUserReviews(DataContext _context,IMapper _mapper,string userId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(r => r.Consultant.Id == userId)
                .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public static Tuple<int, int> GetAverageReviewAndTotalStarRating(List<ReviewDto> listOfReviews)
            {
                int totalStarRating = 0;
                int averageStarRating = 0;
                foreach (var review in listOfReviews)
                {
                    totalStarRating += review.StarRating;
                }
                if (listOfReviews.Count != 0)
                {
                    averageStarRating = totalStarRating / listOfReviews.Count;
                }

                var tuple = new Tuple<int, int>(totalStarRating, averageStarRating);

                return tuple;
            }
    }
}