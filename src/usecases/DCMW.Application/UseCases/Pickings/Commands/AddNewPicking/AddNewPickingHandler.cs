using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Commands.AddNewPicking
{
    public class AddNewPickingHandler : IRequestHandler<AddNewPickingRequest, Result>
    {
        public Task<Result> Handle(AddNewPickingRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
