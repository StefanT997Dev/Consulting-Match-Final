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