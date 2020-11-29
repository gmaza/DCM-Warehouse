using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors
{
    public class SaveNewDistrbutorHandler : IRequestHandler<SaveNewDistrbutorRequest, Result>
    {
        public Task<Result> Handle(SaveNewDistrbutorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
