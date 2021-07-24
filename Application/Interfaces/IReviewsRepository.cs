using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IReviewsRepository
    {
        Task<List<ReviewDto>> GetUserReviews(string userId);
    }
}