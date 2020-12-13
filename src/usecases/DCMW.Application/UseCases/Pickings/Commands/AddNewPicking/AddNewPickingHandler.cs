using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Pickings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Commands.AddNewPicking
{
    public class AddNewPickingHandler : IRequestHandler<AddNewPickingRequest, Result>
    {
        private readonly IPickingRepository pickingRepository;
        private readonly IProductsRepository productsRepository;

        public AddNewPickingHandler(IPickingRepository pickingRepository, IProductsRepository productsRepository)
        {
            this.pickingRepository = pickingRepository;
            this.productsRepository = productsRepository;
        }

        public async Task<Result> Handle(AddNewPickingRequest request, CancellationToken cancellationToken)
        {
            var pickingDoctor = new PickingDoctor(Guid.NewGuid(), 
                request.DoctorID, 
                request.FullName,
                request.MobileNumber, 
                request.PersonalNumber);

            var products = await productsRepository.GetByIDs(request.Products.Select(p => p.ProductID));

            var pickingProducts = from product in products
                                  join requestProduct in request.Products
                                  on product.ID equals requestProduct.ProductID
                                  select new PickingProduct(Guid.NewGuid(),
                                                            product.ID,
                                                            product.Name,
                                                            product.Code,
                                                            product.Description,
                                                            requestProduct.Quantity,
                                                            requestProduct.Unit);

            var picking = new Picking(Guid.NewGuid(), request.Date, pickingDoctor, pickingProducts);

            return await pickingRepository.Insert(picking);
        }
    }
}
