using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schedules
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ScheduleDto Schedule { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
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
                var client = await _context.Users.FirstOrDefaultAsync(u => u.UserName==_userAccessor.GetUsername());

                var consultant = await _context.Users.FindAsync(request.Schedule.TargetConsultantId);

                var schedule = new Schedule
                {
                    Client=client,
                    Consultant=consultant,
                    StartDateAndTime=request.Schedule.StartDateAndTime,
                    EndDateAndTime=request.Schedule.EndDateAndTime
                };

                _context.Schedules.Add(schedule);

                var result = await _context.SaveChangesAsync()>0;

                if(result)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Failed to schedule a consulting session");
            }
        }
    }
}