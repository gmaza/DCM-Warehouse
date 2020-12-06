using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Pickings
{
    public class PickingProduct : BaseEntity
    {
        private PickingProduct() { }

        public PickingProduct(Guid id, Guid productID, string name, string code, string description, decimal quantity, string unit) : base(id)
        {
            _productID = productID;
            _name = name;
            _code = code;
            _description = description;
            _quantity = quantity;
            _unit = unit;
        }

        private Guid _productID;
        private string _name;
        private string _code;
        private string _description;
        private decimal _quantity;
        private string _unit;

        public Guid ProductID
        {
            get => _productID;
            set => value = _productID;
        }

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

        public decimal SumAmount
        {
            get => _quantity * _price;
        }
    }
}
