using System;
using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus
{
    public class MediatrHandler(IMediator _mediator) : IMediatrHandler
    {
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
