using System;

namespace DCMW.Domain.Deliveries
{
    public class DeliveryProduct : BaseEntity
    {
        private DeliveryProduct(){}

        public DeliveryProduct(string name, string code, string description, decimal price, decimal quantity, string unit)
        {
            _name = name;
            _code = code;
            _description = description;
            _price = price;
            _quantity = quantity;
            _unit = unit;
        }

        private string _name;
        private string _code;
        private string _description;
        private decimal _price;
        private decimal _quantity;
        private string _unit;

        public string Name
        {
            get => _name;
            set => value = _name;
        }

        public string Code
        {
            get => _code;
            set => value = _code;
        }

        public string Description
        {
            get => _description;
            set => value = _description;
        }

        public decimal Price
        {
            get => _price;
            set => value = _price;
        }
        public decimal Quantity { get => _quantity; set => _quantity = value; }
        public string Unit { get => _unit; set => _unit = value; }

        public decimal SumAmount {
            get => _quantity * _price;
        }
    }
}