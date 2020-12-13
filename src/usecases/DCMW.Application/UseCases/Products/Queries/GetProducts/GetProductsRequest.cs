using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string SearchWord { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
