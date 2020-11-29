using System;

namespace DCMW.Domain.Products
{
    public partial class Product
    {
        public Product(Guid id, string name, string code, string desc, decimal defaultPrice) : base(id)
        {
            _name = name;
            _code = code;
            _description = desc;
            _defaultPrice = defaultPrice;
        }
    }
}
