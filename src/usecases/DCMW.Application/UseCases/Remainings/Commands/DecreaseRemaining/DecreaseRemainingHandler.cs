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
    class DecreaseRemainingHandler : IRequestHandler<DecreaseRemainingRequest, Result>
    {
        private readonly IRemaininRepository remaininRepository;

        public DecreaseRemainingHandler(IRemaininRepository remaininRepository)
        {
            this.remaininRepository = remaininRepository;
        }

        public async Task<Result> Handle(DecreaseRemainingRequest request, CancellationToken cancellationToken)
        {
            var (remaining, lastUpdateDate) = await remaininRepository.GetByProduct(request.ProductID);
            remaining.Decrease(request.Amount);
            return await remaininRepository.Update(remaining, lastUpdateDate);
        }
    }
}
