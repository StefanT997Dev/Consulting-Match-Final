using Application.Interfaces.Repositories.Package;
using AutoMapper;
using Domain;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class PackageRepository : Repository<Package>, IPackageRepository
	{
		public PackageRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
