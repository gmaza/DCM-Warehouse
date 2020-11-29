using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors.Queries.GetDistrbutors
{
    public class GetDistrbutorsHandler : IRequestHandler<GetDistrbutorsRequest, GetDistrbutorsResponse>
    {
        public Task<GetDistrbutorsResponse> Handle(GetDistrbutorsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
