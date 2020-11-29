using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors
{
    public class SaveNewDoctorHandler : IRequestHandler<SaveNewDoctorRequest, Result>
    {
        public Task<Result> Handle(SaveNewDoctorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
