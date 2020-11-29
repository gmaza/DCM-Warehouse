using System;

namespace DCMW.Domain.Product
{
    public partial class Product : BaseEntity
    {
        private string _name;

        private string _code;

        private string _description;

        private decimal _defaultPrice;

        public string Name
        {
            get => _name;
        }

        public string Code
        {
            get => _code;
        }

        public string Description
        {
            get => _description;
        }

        public decimal DefaultPrice
        {
            get => _defaultPrice;
        }
    }
}