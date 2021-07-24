using System.Collections.Generic;
using Application.DTOs;

namespace Application.Profiles
{
    public class Profile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public int NumberOfReviews { get; set; }
        public int AverageStarReview { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}