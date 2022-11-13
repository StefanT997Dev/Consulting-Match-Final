using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.JobApplications;
using MediatR;
using Persistence;

namespace Application.JobApplications
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public JobApplicationDto JobApplication { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly IJobApplicationRepository _jobApplicationRepository;
			private readonly DataContext _context;

			public Handler(
				IJobApplicationRepository jobApplicationRepository, 
				DataContext context)
			{
				_jobApplicationRepository = jobApplicationRepository;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				using (var transaction = await _context.Database.BeginTransactionAsync())
				{
					try
					{
						var result = await _jobApplicationRepository.AddAsync(request.JobApplication);

						/*if (result)
						{
							await _emailSender.SendEmail();
						}*/

						await transaction.CommitAsync();

						return Result<Unit>.Success(Unit.Value);
					}
					catch (System.Exception)
					{
						await transaction.RollbackAsync();
					}
				}
				return Result<Unit>.Failure("Nismo uspeli da sačuvamo vašu prijavu, molimo Vas da nas kontaktirate kako bismo Vam pomogli");
			}
		}
	}
}
