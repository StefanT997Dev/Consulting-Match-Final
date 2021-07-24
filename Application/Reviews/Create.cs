using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
            public ReviewDto Review { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
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

                var result = await _context.Reviews.FindAsync(review.Consultant.Id,review.Client.Id);

                if(result!=null)
                {
                    return Result<Unit>.Failure("Cannot post a review twice");
                }

                _context.Reviews.Add(review);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}