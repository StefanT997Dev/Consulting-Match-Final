using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Consultants
{
    public class Search
    {
        public class Command : IRequest<Result<List<ConsultantSearchDto>>>
        {
            public SkillDto Skill { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<List<ConsultantSearchDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ConsultantSearchDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.Skill.Name=="")
                {
                    return null;
                }

                var appUserSkills = await _context.AppUserSkills
                    .Where(aus => aus.Skill.Name.StartsWith(request.Skill.Name))
                    .Include(aus => aus.Consultant)
                    .Include(aus => aus.Skill)
                    .ToListAsync();

                var usersWithDesiredSkill = new List<AppUser>();

                foreach (var appUserSkill in appUserSkills)
                {
                    if(!usersWithDesiredSkill.Contains(appUserSkill.Consultant))
                    {
                         usersWithDesiredSkill.Add(appUserSkill.Consultant);
                    }
                }

                var listOfConsultantSeacthDtos = new List<ConsultantSearchDto>();

                foreach (var user in usersWithDesiredSkill)
                {
                    listOfConsultantSeacthDtos.Add(
                        new ConsultantSearchDto
                        {
                            DisplayName = user.DisplayName,
                            Skills = GetSkills(user).Result
                        }
                    );
                }
                return Result<List<ConsultantSearchDto>>.Success(listOfConsultantSeacthDtos);
            }

            private async Task<ICollection<SkillDto>> GetSkills(AppUser user)
            {
                var appUserSkills = await _context.AppUserSkills
                    .Where(aus => aus.ConsultantId==user.Id)
                    .Include(aus => aus.Skill)
                    .ToListAsync();

                var skillDtoList = new List<SkillDto>();

                foreach(var appUserSkill in appUserSkills)
                {
                    skillDtoList.Add(_mapper.Map<SkillDto>(appUserSkill.Skill));
                }

                return skillDtoList;
            }
        }
    }
}