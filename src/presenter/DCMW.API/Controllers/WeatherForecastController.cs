using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DCMW.Domain.Product;

namespace DCMW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<Product> Get()
        {
            var prod = new Product(Guid.NewGuid(), "მსხარლი", "cs1", "msxali kaia", 30);
            return await Task.FromResult(prod);
        }
    }
}
