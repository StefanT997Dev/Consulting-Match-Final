using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Wrappers;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class FilteredList
    {
        public class Query : IRequest<PagedResult<List<UserDto>>>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<Query, PagedResult<List<UserDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<PagedResult<List<UserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var totalRecords = await _context.Users.CountAsync();

                int numberOfPages = request.PageSize>totalRecords?totalRecords/request.PageSize+1:totalRecords/request.PageSize;

                return PagedResult<List<UserDto>>.Success(users,numberOfPages,totalRecords);
            }
        }
    }
}