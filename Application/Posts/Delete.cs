using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var task = await _context.Posts.FindAsync(request.Id);

                if(task==null) return null;

                _context.Remove(task);

                var result = await _context.SaveChangesAsync()>0;

                if(!result) return Result<Unit>.Failure("Failed to delete post");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}