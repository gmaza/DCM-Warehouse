using DCMW.Domain.Abstractions.DomainEvents;
using DCMW.Domain.Entities.Remainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Events.Remainings
{
    public class RemainingCreated : IDomainEvent
    {
        public Remaining Remaining { get; set; }
    }
}
