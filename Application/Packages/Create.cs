using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Package;
using MediatR;
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
			private readonly IPackageRepository _packageRepository;

			public Handler(IPackageRepository packageRepository)
			{
				_packageRepository = packageRepository;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				if (await _packageRepository.AddAsync(request.Package))
				{
					return Result<Unit>.Success(Unit.Value);
				}
				return Result<Unit>.Failure("Nismo uspeli da dodamo novi paket usluge");
			}
		}
	}
}
