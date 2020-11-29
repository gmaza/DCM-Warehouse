using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorRequest, Result>
    {
        public Task<Result> Handle(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
