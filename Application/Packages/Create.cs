using Application.Core;
using Application.DTOs;
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

			public Handler(DataContext context, IPackageRepository packageRepository)
			{
				_context = context;
				_packageRepository = packageRepository;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				if (await _context.Packages
					.AnyAsync(x => x.MentorId == request.Package.MentorId))
				{
					return Result<Unit>.Failure("Već ste napravili paket");
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
