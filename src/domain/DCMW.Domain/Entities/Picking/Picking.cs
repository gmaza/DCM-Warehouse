using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Pickings
{
    public partial class Picking
    {
        public Picking(Guid id, DateTime date, PickingDoctor doctor, IEnumerable<PickingProduct> products) : base(id)
        {
            _date = date;
            _doctor = doctor;
            AddProducts(products);
        }

        public void AddProduct(PickingProduct product)
        {
            if (product == null)
                return;

            _products.Add(product);
        }

        public void AddProducts(IEnumerable<PickingProduct> products)
        {
            if (products == null)
                return;

            _products.AddRange(products);
        }
    }
}
