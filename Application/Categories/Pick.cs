using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Pick
    {
        public class Command : IRequest
        {
            public AppUserCategoryDto AppUserCategory { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var appUserCategory = new AppUserCategory
                {
                    AppUserId=request.AppUserCategory.ConsultantId,
                    CategoryId=request.AppUserCategory.CategoryId
                };

                _context.AppUserCategories.Add(appUserCategory);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}