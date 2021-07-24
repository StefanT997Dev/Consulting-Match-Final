using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string UserEmail { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UserManager<AppUser> _userManager;
            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.UserEmail);

                if(user==null)
                {
                    return Result<Unit>.Failure("Failed to find user");
                }

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Failed to delete the user");
            }
        }
    }
}