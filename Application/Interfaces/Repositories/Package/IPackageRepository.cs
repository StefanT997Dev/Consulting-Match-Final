using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Package
{
	public interface IPackageRepository : IRepository<Domain.Package>
	{
		Task<bool> IsPackageLimitExceeded(string mentorId);
	}
}
