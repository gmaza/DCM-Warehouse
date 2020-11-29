using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Products
{
    public class SaveNewProductHandler : IRequestHandler<SaveNewProductRequest, Result>
    {
        public Task<Result> Handle(SaveNewProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
