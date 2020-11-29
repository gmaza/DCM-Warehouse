using System;

namespace DCMW.Domain.Delivery
{
    public class Delivery : BaseEntity
    {
        private Delivery() { }

        private DateTime _date;

        private DeliveryDistributor _distributor;

        private List<DeliveryProduct> _products = new List<DeliveryProduct>();

        public DateTime Date
        {
            get => _date;
        }

        public DeliveryDistributor Distributor
        {
            get => _distributor;
        }

        public ReadOnlyCollection<DeliveryProduct> Products {
            get => _products.AsReadOnly();
        }
    }
}