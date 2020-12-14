using DCMW.Application.UseCases.Deliveries;
using DCMW.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCMW.API.Controllers
{
    [Route("api/[controller]")]
    public class DeliveriesController : ApiController
    {
        [HttpGet("Range")]
        public async Task<GetDeliveriesResponse> GetRange([FromQuery] GetDeliveriesRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Add")]
        public async Task<Result> Save([FromBody] AddNewDeliveryRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
