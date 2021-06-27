using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class MessageHub : Hub
    {
        // private readonly IMediator _mediator;
        // public MessageHub(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        // public async Task SendComment(Send.Command command)
        // {
        //     var message = await _mediator.Send(command);
        // }
    }
}