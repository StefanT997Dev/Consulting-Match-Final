using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
    public class Choose
    {
        public class Command : IRequest<Result<Unit>>
        {
            public List<SkillDto> Skills { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var consultant = await _context.Users.FirstOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                var appUserSkillsList = new List<AppUserSkill>();

                foreach (var skill in request.Skills)
                {
                    var appUserSkill = new AppUserSkill
                    {
                        ConsultantId = consultant.Id,
                        SkillId = skill.Id
                    };

                    appUserSkillsList.Add(appUserSkill);
                }

                _context.AppUserSkills.AddRange(appUserSkillsList);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}