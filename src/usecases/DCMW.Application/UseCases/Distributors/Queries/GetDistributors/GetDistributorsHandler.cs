using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors.Queries.GetDistrbutors
{
    public class GetDistrbutorsHandler : IRequestHandler<GetDistrbutorsRequest, GetDistrbutorsResponse>
    {
        private readonly IDistributorRepository distributorRepository;

        public GetDistrbutorsHandler(IDistributorRepository distributorRepository)
        {
            this.distributorRepository = distributorRepository;
        }

        public async Task<GetDistrbutorsResponse> Handle(GetDistrbutorsRequest request, CancellationToken cancellationToken)
        {
            var items = await distributorRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await distributorRepository.Count(request.SearchWord);

            return new GetDistrbutorsResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
