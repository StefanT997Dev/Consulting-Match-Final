using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Consultants
{
    public class CreateAPost
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
            public PostDto Post { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(c => c.Post).SetValidator(new CreateAPostValidator());
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
                var consultant = await _context.Users.FindAsync(request.Id);

                var post = new Post{
                    Id=request.Post.Id,
                    Title=request.Post.Title,
                    Description=request.Post.Description
                };

                _context.Posts.Add(post);

                var result = await _context.SaveChangesAsync()>0;

                if(!result) return Result<Unit>.Failure("Failed to create post");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}