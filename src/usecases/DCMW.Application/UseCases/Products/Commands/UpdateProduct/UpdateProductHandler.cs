using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Result>
    {
        private readonly IProductsRepository productsRepository;

        public UpdateProductHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<Result> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var (product, updateDate) = await productsRepository.Get(request.Id);

            product.ChangeCode(request.Code)
                .ChangeDefaultPrice(request.DefaultPrice)
                .ChangeDescription(request.Description)
                .ChangeName(request.Name);

            return await productsRepository.Update(product, updateDate.Value);
        }
    }
}
