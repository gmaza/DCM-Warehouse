using DCMW.Application.UseCases.Pickings.Commands.AddNewPicking;
using DCMW.Application.UseCases.Pickings.Queries.GetPickings;
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
    public class PickingsController : ApiController
    {
        [HttpGet("Range")]
        public async Task<GetPickingsResponse> GetRange([FromQuery] GetPickingsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Add")]
        public async Task<Result> Save([FromBody] AddNewPickingRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
