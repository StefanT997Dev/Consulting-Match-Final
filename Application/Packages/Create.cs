using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using Application.Interfaces.Repositories.Package;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packages
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public PackageDto Package { get; set; }
		}
		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IPackageRepository _packageRepository;
			private readonly IMentorsRepository _mentorsRepository;

			public Handler(DataContext context, IPackageRepository packageRepository, IMentorsRepository mentorsRepository)
			{
				_context = context;
				_packageRepository = packageRepository;
				_mentorsRepository = mentorsRepository;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				if (!await _mentorsRepository.IsMentor(request.Package.MentorId))
				{
					return Result<Unit>.Failure("Klijent nije u mogućnosti da kreira paket");
				}

				if (await _packageRepository.IsPackageLimitExceeded(request.Package.MentorId))
				{
					return Result<Unit>.Failure("Nije moguće dodati više od 3 paketa");
				}

				if (await _context.Packages
					.AnyAsync(x => x.MentorId == request.Package.MentorId &&
					x.NumberOfSessions == request.Package.NumberOfSessions
					&& x.DurationInMonths == request.Package.DurationInMonths))
				{
					return Result<Unit>.Failure("Već ste napravili isti paket");
				}

				if (await _packageRepository.AddAsync(request.Package))
				{
					return Result<Unit>.Success(Unit.Value);
				}
				return Result<Unit>.Failure("Nismo uspeli da dodamo novi paket usluge");
			}
		}
	}
}
