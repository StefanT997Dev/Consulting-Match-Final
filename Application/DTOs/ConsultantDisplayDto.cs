using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class ConsultantDisplayDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public int NumberOfReviews { get; set; }
        public int TotalStarRating { get; set; }
        public int AverageStarReview { get; set; }
        public ICollection<string> Categories { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}