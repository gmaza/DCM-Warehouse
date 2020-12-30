using DCMW.Domain.Abstractions.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.EventHandlers
{
    public class DomainEventFactory
    {
        public static DomainEvent<B> CreateInstanse<B>(B a) where B : IDomainEvent
        {
            return new DomainEvent<B>(a);
        }
    }
    public class DomainEvent<T> : INotification where T : IDomainEvent
    {
        public DomainEvent(T instanse)
        {
            Instanse = instanse;
        }

        public T Instanse { get; }
    }
}
