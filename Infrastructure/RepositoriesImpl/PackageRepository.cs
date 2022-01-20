using Application.Interfaces.Repositories.Package;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesImpl
{
	public class PackageRepository : Repository<Package>, IPackageRepository
	{
		public PackageRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<bool> IsPackageLimitExceeded(string mentorId)
		{
			return await entities.CountAsync(x => x.MentorId == mentorId) == 3;
		}
	}
}
