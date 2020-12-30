using DCMW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsResponse
    {
        public IEnumerable<Product> Items { get;  set; }
        public int Quantity { get; set; }
    }
}
