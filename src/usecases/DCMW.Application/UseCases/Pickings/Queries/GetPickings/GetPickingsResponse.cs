using DCMW.Domain.Pickings;
using System.Collections.Generic;

namespace DCMW.Application.UseCases.Pickings.Queries.GetPickings
{
    public class GetPickingsResponse
    {
        public IEnumerable<Picking> Items { get;  set; }
        public int Quantity { get;  set; }
    }
}