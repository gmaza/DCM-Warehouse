using DCMW.Application.UseCases.Products;
using DCMW.Application.UseCases.Products.Queries.GetProducts;
using DCMW.Common.Models;
using DCMW.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCMW.API.Controllers
{
    [Route("/api/Products")]
    public class ProductsController : ApiController
    {

        [HttpGet("Range")]
        public async Task<GetProductsResponse> GetRange([FromQuery] GetProductsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("SaveNew")]
        public async Task<Result> Save([FromBody] SaveNewProductRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody] UpdateProductRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
