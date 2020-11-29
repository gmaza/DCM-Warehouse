using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries.Queries.GetDeliveris
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        public Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
