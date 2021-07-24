using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateCategoryDto Category { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Category).SetValidator(new CategoriesValidator());
            }
        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    Id=request.Category.Id,
                    Name=request.Category.Name
                };

                _context.Categories.Add(category);

                var result = await _context.SaveChangesAsync()>0;

                if(result)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Failed to add a new category");
            }
        }
    }
}