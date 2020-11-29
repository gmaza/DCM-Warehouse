using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Queries.GetPickings
{
    public class GetPickingsHandler : IRequestHandler<GetPickingsRequest, GetPickingsResponse>
    {
        public Task<GetPickingsResponse> Handle(GetPickingsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
