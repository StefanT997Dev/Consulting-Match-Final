using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public class ListForConsultant
    {
        public class Query : IRequest<Result<List<Post>>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Post>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Post>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts.Where(p => p.Consultant.Id==request.Id).ToListAsync();

                if(posts.Count==0)
                {
                    return Result<List<Post>>.Failure("Consultant hasn't posted any posts yet");
                }

                return Result<List<Post>>.Success(posts);
            }
        }
    }
}