using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReviewsRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ReviewDto>> GetReviews(string userId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(r => r.Consultant.Id == userId)
                .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}