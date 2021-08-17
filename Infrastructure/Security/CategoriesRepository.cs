using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoriesRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<string>> GetCategories(ConsultantDisplayDto user)
        {
            return await _context.AppUserCategories
                        .Where(auc => auc.AppUserId == user.Id)
                        .Select(auc => auc.Category)
                        .ProjectTo<string>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }
    }
}