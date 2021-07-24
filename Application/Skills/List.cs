using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
    public class List
    {
        public class Query : IRequest<Result<List<SkillDto>>>
        {
            public Guid CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<SkillDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(IMapper mapper, DataContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<SkillDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var skills = await _context.CategorySkills
                    .AsNoTracking()
                    .Where(c => c.Category.Id == request.CategoryId)
                    .Select(cs => cs.Skill)
                    .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<SkillDto>>.Success(skills);
            }
        }
    }
}