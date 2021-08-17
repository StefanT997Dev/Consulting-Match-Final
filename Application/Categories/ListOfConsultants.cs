using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Profiles;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
                var consultants = await _context.AppUserCategories
                    .Where(auc => auc.CategoryId==request.Id)
                    .Select(auc => auc.AppUser)
                    .ProjectTo<Profiles.Profile>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                foreach (var consultant in consultants)
                {
                    var reviews = await _context.Reviews
                        .Where(r => r.Consultant.Id == consultant.Id)
                        .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    consultant.Reviews=reviews;
                }

                return Result<ICollection<Profiles.Profile>>.Success(consultants);
            }
        }
    }
}