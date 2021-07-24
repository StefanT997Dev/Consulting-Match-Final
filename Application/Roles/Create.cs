using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Roles
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string RoleName { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public Handler(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var role = new IdentityRole
                {
                    Name=request.RoleName   
                };

                var result = await _roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Failed to create a new role");
            }
        }
    }
}