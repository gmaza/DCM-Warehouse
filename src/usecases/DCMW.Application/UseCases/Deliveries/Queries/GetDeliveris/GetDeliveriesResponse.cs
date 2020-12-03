using DCMW.Domain.Deliveries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries
{
    public class GetDeliveriesResponse
    {
        public IEnumerable<Delivery> Items { get; internal set; }
        public int Quantity { get; internal set; }
    }
}
