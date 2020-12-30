using DCMW.Domain.Events.Deliveries;
using System;
using System.Collections.Generic;

namespace DCMW.Domain.Deliveries {
    public partial class Delivery {
        public Delivery(Guid id, DateTime date, DeliveryDistributor distributor, IEnumerable<DeliveryProduct> products) : base(id)
        {
            _date = date;
            _distributor = distributor;
            AddProducts(products);

            Events.Add(new DeliveryCreated { Delivery = this });
        }

        public void AddProduct(DeliveryProduct product){
            if(product == null)
                return;

            _products.Add(product);
        }

        public void AddProducts(IEnumerable<DeliveryProduct> products){
            if(products == null)
                return;

            _products.AddRange(products);
        }
    }
}