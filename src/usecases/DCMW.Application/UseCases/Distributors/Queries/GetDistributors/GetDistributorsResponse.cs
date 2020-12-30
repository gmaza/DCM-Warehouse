using DCMW.Domain.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors.Queries.GetDistrbutors
{
    public class GetDistrbutorsResponse
    {
        public IEnumerable<Distributor> Items { get;  set; }
        public int Quantity { get;  set; }
    }
}
