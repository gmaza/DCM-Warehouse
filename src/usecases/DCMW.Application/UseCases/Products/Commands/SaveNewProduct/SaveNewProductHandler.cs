using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Products;
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
        private readonly IProductsRepository productsRepository;

        public SaveNewProductHandler(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<Result> Handle(SaveNewProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), request.Name, request.Code, request.Description, request.DefaultPrice);

            return await productsRepository.Insert(product);
        }
    }
}
