using DCMW.Domain.Pickings;
using System.Collections.Generic;

namespace DCMW.Application.UseCases.Pickings.Queries.GetPickings
{
    public class GetPickingsResponse
    {
        public IEnumerable<Picking> Items { get; internal set; }
        public int Quantity { get; internal set; }
    }
}