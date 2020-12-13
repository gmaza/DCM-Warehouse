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
    public class GetRemainingsHandler : IRequestHandler<GetRemainingsRequest, GetRemainingsResponse>
    {
        private readonly IRemaininRepository remaininRepository;

        public GetRemainingsHandler(IRemaininRepository remaininRepository)
        {
            this.remaininRepository = remaininRepository;
        }

        public async Task<GetRemainingsResponse> Handle(GetRemainingsRequest request, CancellationToken cancellationToken)
        {
            var items = await remaininRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await remaininRepository.Count(request.SearchWord);

            return new GetRemainingsResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
