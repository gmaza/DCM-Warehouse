using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Queries.GetPickings
{
    public class GetPickingsHandler : IRequestHandler<GetPickingsRequest, GetPickingsResponse>
    {

        IPickingRepository _pickingRepository;

        public GetPickingsHandler(IPickingRepository pickingRepository)
        {
            _pickingRepository = pickingRepository;
        }

        public async Task<GetPickingsResponse> Handle(GetPickingsRequest request, CancellationToken cancellationToken)
        {
            var items = await _pickingRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await _pickingRepository.Count(request.SearchWord);

            return new GetPickingsResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
