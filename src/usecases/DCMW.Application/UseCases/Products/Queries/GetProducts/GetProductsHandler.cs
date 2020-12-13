using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductsRepository productRepository;

        public GetProductsHandler(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var items = await productRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await productRepository.Count(request.SearchWord);

            return new GetProductsResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
