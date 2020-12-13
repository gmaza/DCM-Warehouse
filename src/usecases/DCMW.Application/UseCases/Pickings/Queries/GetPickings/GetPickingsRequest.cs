using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Queries.GetPickings
{
    public class GetPickingsRequest : IRequest<GetPickingsResponse>
    {
        public string SearchWord { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
