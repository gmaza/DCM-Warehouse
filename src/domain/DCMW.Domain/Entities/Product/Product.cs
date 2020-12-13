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

        public Product ChangeName(string name)
        {
            _name = name;
            return this;
        }

        public Product ChangeCode(string code)
        {
            _code = code;
            return this;
        }

        public Product ChangeDescription(string descrption)
        {
            _description = descrption;
            return this;
        }

        public Product ChangeDefaultPrice(decimal defaultPrice)
        {
            _defaultPrice = defaultPrice;
            return this;
        }
    }
}
