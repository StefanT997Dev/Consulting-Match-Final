using Application.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTests
{
	public class HandlerBase<TRepoInterface> where TRepoInterface : class
	{
		protected readonly CancellationToken cancellationToken;
		protected Mock<TRepoInterface> repository;
		public HandlerBase()
		{
			cancellationToken = new CancellationToken();
			repository = new Mock<TRepoInterface>();
		}
	}
}
