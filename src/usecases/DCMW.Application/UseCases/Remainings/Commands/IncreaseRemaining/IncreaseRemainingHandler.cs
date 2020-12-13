using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class IncreaseRemainingHandler : IRequestHandler<IncreaseRemainingRequest, Result>
    {
        private readonly IRemaininRepository remaininRepository;

        public IncreaseRemainingHandler(IRemaininRepository remaininRepository)
        {
            this.remaininRepository = remaininRepository;
        }

        public async Task<Result> Handle(IncreaseRemainingRequest request, CancellationToken cancellationToken)
        {
            var (remaining, lastUpdateDate) = await remaininRepository.GetByProduct(request.ProductID);
            remaining.Increase(request.Amount);
            return await remaininRepository.Update(remaining, lastUpdateDate);
        }
    }
}
