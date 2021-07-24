using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Followers
{
    public class Dashboard
    {
        public class Query : IRequest<Result<DashboardStatsDto>>
        {
            public string TargetUserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<DashboardStatsDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<DashboardStatsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userFollowings = await _context.UserFollowings
                        .AsNoTracking()
                        .Where(uf => uf.ObserverId == request.TargetUserId)
                        .Select(uf => uf.Target)
                        .ProjectTo<DashboardUserDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                var userFollowers = await _context.UserFollowings
                        .AsNoTracking()
                        .Where(uf => uf.TargetId == request.TargetUserId)
                        .Select(uf => uf.Observer)
                        .ProjectTo<DashboardUserDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                return Result<DashboardStatsDto>.Success(new DashboardStatsDto{Followers=userFollowers,Following=userFollowings});
            }
        }
    }
}