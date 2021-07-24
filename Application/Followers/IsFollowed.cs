using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Followers
{
    public class IsFollowed
    {
        public class Query : IRequest<Result<IsFollowedDto>>
        {
            public string TargetUserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<IsFollowedDto>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<IsFollowedDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var observer = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var target = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.TargetUserId);

                var result = await _context.UserFollowings.FindAsync(observer.Id,target.Id);

                if(result ==null)
                {
                    return Result<IsFollowedDto>.Success(new IsFollowedDto{IsFollowed=false});
                }
                else
                {
                    return Result<IsFollowedDto>.Success(new IsFollowedDto{IsFollowed=true});
                }
            }
        }
    }
}