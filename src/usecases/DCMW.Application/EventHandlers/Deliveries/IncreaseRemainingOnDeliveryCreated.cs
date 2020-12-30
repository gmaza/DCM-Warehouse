using DCMW.Application.UseCases.Remainings;
using DCMW.Domain.Events.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.EventHandlers.Deliveries
{
    class IncreaseRemainingOnDeliveryCreated : INotificationHandler<DomainEvent<DeliveryCreated>>
    {
        private readonly IMediator mediator;

        public IncreaseRemainingOnDeliveryCreated(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(DomainEvent<DeliveryCreated> notification, CancellationToken cancellationToken)
        {
            var requests = notification.Instanse.Delivery.Products.Select(p => new IncreaseRemainingRequest
            {
                Amount = (int)p.Quantity,
                ProductID = p.ProductID,
            });
            foreach (var request in requests)
            {
                await mediator.Send(request);
            }
        }

    }
}
