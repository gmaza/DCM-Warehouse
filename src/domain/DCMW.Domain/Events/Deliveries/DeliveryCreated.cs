using DCMW.Domain.Abstractions.DomainEvents;
using DCMW.Domain.Deliveries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Events.Deliveries
{
    public class DeliveryCreated : IDomainEvent
    {
        public Delivery Delivery { get; set; }
    }
}
