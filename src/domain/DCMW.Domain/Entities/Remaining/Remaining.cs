using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Entities.Remainings
{
    public partial class Remaining
    {
        public Remaining(Guid id, Guid productID, decimal amount, string name, string code, string desc, decimal defaultPrice) : base(id)
        {
            _productID = productID;
            _amount = amount;
            _name = name;
            _code = code;
            _description = desc;
            _defaultPrice = defaultPrice;
        }
    }
}
