using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors.Commands.UpdateDistrbutor
{
    public class UpdateDistrbutorHandler : IRequestHandler<UpdateDistrbutorRequest, Result>
    {
        public Task<Result> Handle(UpdateDistrbutorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
