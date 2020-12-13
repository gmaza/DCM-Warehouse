using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Entities.Remainings
{
    public partial class Remaining
    {
        public Remaining(Guid id, Guid productID, decimal amount, string name, string code, string desc) : base(id)
        {
            _productID = productID;
            _amount = amount;
            _name = name;
            _code = code;
            _description = desc;
        }

        public Remaining Decrease(int amount)
        {
            if (amount < _amount)
                throw new Exception("ბალანსი 0-ზე ნაკლები არ შეიძლება იყოს");

            _amount -= amount;
            return this;
        }

        public Remaining Increase(int amount)
        {
            _amount += amount;
            return this;
        }
    }
}
