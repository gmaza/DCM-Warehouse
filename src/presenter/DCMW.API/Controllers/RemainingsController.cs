using DCMW.Application.UseCases.Remainings;
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
    public class RemainingsController : ApiController
    {
        [HttpGet("Range")]
        public async Task<GetRemainingsResponse> GetRange([FromQuery] GetRemainingsRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
