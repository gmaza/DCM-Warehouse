using DCMW.Domain.Entities.Remainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class GetRemainingsResponse
    {
        public IEnumerable<Remaining> Items { get;  set; }
        public int Quantity { get;  set; }
    }
}
