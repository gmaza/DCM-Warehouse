using DCMW.Application.UseCases.Remainings;
using DCMW.Domain.Events.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.EventHandlers.Products
{
    public class AddRemainingOnProductCreated : INotificationHandler<DomainEvent<ProductCreated>>
    {
        private readonly IMediator mediator;

        public AddRemainingOnProductCreated(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(DomainEvent<ProductCreated> notification, CancellationToken cancellationToken)
        {
            await mediator.Send(new SaveNewRemainingRequest
            {
                Code = notification.Instanse.Product.Code,
                Description = notification.Instanse.Product.Description,
                Name = notification.Instanse.Product.Name,
                Amount = 0,
                ProductID = notification.Instanse.Product.ID,
            });
        }
    }
}
