using CommonServiceLocator;
using DCMW.Application.EventHandlers;
using DCMW.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Infrastructure.DAL.DomainEvents
{
    public static class DomainEventDispacherExtension
    {
        static public void DispatchDomainEvents(this BaseEntity entity)
        {
            IMediator mediator = ServiceLocator.Current.GetInstance<IMediator>();

            foreach (var item in entity.Events)
            {
                var type = typeof(DomainEvent<>).MakeGenericType(item.GetType());

                var instance = Activator.CreateInstance(type, item);
                mediator.Publish(instance);
            }

            entity.Events.Clear();
        }
    }
}
