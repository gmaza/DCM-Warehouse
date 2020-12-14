using DCMW.Application.UseCases.Distrbutors;
using DCMW.Application.UseCases.Distrbutors.Commands.UpdateDistrbutor;
using DCMW.Application.UseCases.Distrbutors.Queries.GetDistrbutors;
using DCMW.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCMW.API.Controllers
{
    [Route("/api/Distributors")]
    public class DistributorsController : ApiController
    {

        [HttpGet("Range")]
        public async Task<GetDistrbutorsResponse> GetRange([FromQuery] GetDistrbutorsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Save")]
        public async Task<Result> Save([FromBody] SaveNewDistrbutorRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody] UpdateDistrbutorRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
