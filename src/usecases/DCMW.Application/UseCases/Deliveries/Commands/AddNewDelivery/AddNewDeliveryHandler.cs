using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries
{
    public class AddNewDeliveryHandler : IRequestHandler<AddNewDeliveryRequest, Result>
    {
        public Task<Result> Handle(AddNewDeliveryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
