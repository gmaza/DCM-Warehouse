using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Deliveries;
using DCMW.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries
{
    public class AddNewDeliveryHandler : IRequestHandler<AddNewDeliveryRequest, Result>
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IDistributorRepository distributorRepository;

        public AddNewDeliveryHandler(IDeliveryRepository deliveryRepository,
                                    IProductsRepository productsRepository,
                                    IDistributorRepository distributorRepository)
        {
            this.deliveryRepository = deliveryRepository;
            this.productsRepository = productsRepository;
            this.distributorRepository = distributorRepository;
        }

        public async Task<Result> Handle(AddNewDeliveryRequest request, CancellationToken cancellationToken)
        {
            //get distributor from db and create DeliveryDistributor instance
            var (dis, _) = await distributorRepository.Get(request.DistributorID);
            var deliveryDistributor = new DeliveryDistributor(dis.FullName, dis.MobileNumber, dis.Email, dis.CompanyName);

            //get products from db and create DeliveryProduct instances
            var products = await productsRepository.GetByIDs(request.Products.Select(p => p.ProductID));

            var deliveryProducts = from productAmountsAndPrice in request.Products
                                   join product in products
                                        on productAmountsAndPrice.ProductID equals product.ID
                                   select new DeliveryProduct(name: product.Name, 
                                                            code: product.Code, 
                                                            description: product.Description, 
                                                            price: product.DefaultPrice, 
                                                            quantity: productAmountsAndPrice.Amoount, 
                                                            unit: productAmountsAndPrice.Unit);

            var delivery = new Delivery(Guid.NewGuid(), request.Date, deliveryDistributor, deliveryProducts);
            return await deliveryRepository.Insert(delivery);
        }
    }
}
