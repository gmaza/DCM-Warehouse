using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Entities.Remainings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class SaveNewRemainingHandler : IRequestHandler<SaveNewRemainingRequest, Result>
    {
        private readonly IRemaininRepository remaininRepository;

        public SaveNewRemainingHandler(IRemaininRepository remaininRepository)
        {
            this.remaininRepository = remaininRepository;
        }

        public async Task<Result> Handle(SaveNewRemainingRequest request, CancellationToken cancellationToken)
        {
            var remaining = new Remaining(Guid.NewGuid(),
                                         productID: request.ProductID,
                                         amount: request.Amount,
                                         name: request.Name,
                                         code: request.Code,
                                         desc: request.Description);

            return await remaininRepository.Insert(remaining);
        }
    }
}
