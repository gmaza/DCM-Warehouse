using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Queries.GetDoctors
{
    public class GetDoctorsHandler : IRequestHandler<GetDoctorsRequest, GetDoctorsResponse>
    {
        public Task<GetDoctorsResponse> Handle(GetDoctorsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
