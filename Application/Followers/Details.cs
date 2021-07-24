using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Followers
{
    public class Details
    {
        public class Query : IRequest<Result<FollowStatsDto>>
        {
            public string UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<FollowStatsDto>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<FollowStatsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userFollowings = await _context.UserFollowings
                        .Where(uf => uf.ObserverId ==request.UserId || uf.TargetId==request.UserId)
                        .ToListAsync();

                int followers=0;
                int following=0;

                foreach(var userFollowing in userFollowings)
                {
                    if(userFollowing.ObserverId==request.UserId)
                    {
                        following++;
                    }
                    else
                    {
                        followers++;
                    }
                }

                var followStats = new FollowStatsDto
                {
                    Followers=followers,
                    Following=following
                };

                return Result<FollowStatsDto>.Success(followStats);
            }
        }
    }
}