using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries.Queries.GetDeliveris
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        IDeliveryRepository _deliveryRepository;

        public GetDeliveriesHandler(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var items = await _deliveryRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await _deliveryRepository.Count(request.SearchWord);
            return new GetDeliveriesResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
