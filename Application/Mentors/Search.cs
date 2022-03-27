/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mentors
{
    public class Search
    {
        public class Command : IRequest<Result<IEnumerable<MentorSearchDto>>>
        {
            public SearchSkillDto Skill { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<IEnumerable<MentorSearchDto>>>
        {
			private readonly IMentorsRepository _mentorsRepository;

			public Handler(IMentorsRepository mentorsRepository)
            {
				_mentorsRepository = mentorsRepository;
			}

            public async Task<Result<IEnumerable<MentorSearchDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                *//*var mentorsWithSkills = await _mentorsRepository
                    .FindAsync<MentorSearchDto>(u => u.Skills.Any(s => s.Skill.Name.StartsWith(request.Skill.Name, StringComparison.InvariantCultureIgnoreCase)));*/

                /*if (!mentorsWithSkills.Any())
                {
                    return Result<IEnumerable<MentorSearchDto>>.Failure("Nismo uspeli da pronađemo nijednog mentora");
                }*//*
                return Result<IEnumerable<MentorSearchDto>>.Success(mentorsWithSkills);
            }
        }
    }
}*/