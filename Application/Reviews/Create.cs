using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public ReviewDto Review { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var consultant = await _context.Users.FindAsync(request.Id);

                var client = await _context.Users.FirstOrDefaultAsync(c => c.UserName == _userAccessor.GetUsername());

                var review = new Review
                {
                    StarRating = request.Review.StarRating,
                    Comment = request.Review.Comment,
                    Consultant = consultant,
                    Client=client
                };

                _context.Reviews.Add(review);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}