using DCMW.Application.UseCases.Doctors;
using DCMW.Application.UseCases.Doctors.Commands.UpdateDoctor;
using DCMW.Application.UseCases.Doctors.Queries.GetDoctors;
using DCMW.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCMW.API.Controllers
{
    [Route("/api/Doctors")]
    public class DoctorsController : ApiController
    {

        [HttpGet("Range")]
        public async Task<GetDoctorsResponse> GetRange([FromQuery] GetDoctorsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Save")]
        public async Task<Result> Save([FromBody] SaveNewDoctorRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody] UpdateDoctorRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
