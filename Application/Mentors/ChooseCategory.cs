using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mentors
{
	public class ChooseCategory
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppUserCategoryDto AppUserCategory { get; set; }
        }

		public class CommandValidator : AbstractValidator<AppUserCategoryDto>
		{
			public CommandValidator()
			{
                RuleFor(x => x.AppUserId).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
            }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
        {
			private readonly IMapper _mapper;
			private readonly DataContext _context;
			private readonly IMentorsRepository _mentorsRepository;

			public Handler(IMapper mapper, DataContext context, IMentorsRepository mentorsRepository)
			{
				_mapper = mapper;
				_context = context;
				_mentorsRepository = mentorsRepository;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
				// naci user-a po id-ju
				// Treba currently logged in user da se vadi preko useraccessor pre nego 
				// da se salje id od frontend i da se autorizuje.
				// var user = await _mentorsRepository.GetMentorAsync<AppUser>(request.AppUserCategory.AppUserId);
				var user = await _context.Users
					.Where(x => x.Id == request.AppUserCategory.AppUserId && x.Role.Name == Application.Resources.Roles.MentorRole)
					.ProjectTo<AppUser>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync();

				if (user == null)
				{
					return Result<Unit>.Failure("Nismo uspeli da pronađemo željenog korisnika.");
				}

				user.CategoryId = request.AppUserCategory.CategoryId;

				var result = await _context.SaveChangesAsync() > 0;

				if (result)
				{
					return Result<Unit>.Success(Unit.Value);
				}
				return Result<Unit>.Failure("Nismo uspeli da izaberemo kategoriju");

				/*if (await _context.AppUserCategories.AnyAsync(x => x.AppUserId == request.AppUserCategory.AppUserId
					&& x.CategoryId == request.AppUserCategory.CategoryId))
				{
					return Result<Unit>.Failure("Već ste izabrali ovu kategoriju");
				}
				if (await _appUserCategoriesRepository.AddAsync(request.AppUserCategory))
				{
					return Result<Unit>.Success(Unit.Value);
				}*/
			}
        }
    }
}