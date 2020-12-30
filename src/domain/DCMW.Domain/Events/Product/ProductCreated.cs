using DCMW.Domain.Abstractions.DomainEvents;
using DCMW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Events.Products
{
    public class ProductCreated : IDomainEvent
    {
        public Product Product { get; set; }
    }
}
 