using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
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
            private readonly RoleManager<Role> _roleManager;
            public Handler(RoleManager<Role> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var role = new Role
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