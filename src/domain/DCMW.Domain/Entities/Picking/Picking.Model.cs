using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Pickings
{
    public partial class Picking : BaseEntity
    {
        private DateTime _date;

        private PickingDoctor _doctor;

        private List<PickingProduct> _products;

        public PickingDoctor Doctor
        {
            get { return _doctor; }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public ReadOnlyCollection<PickingProduct> Products
        {
            get => _products.AsReadOnly();
        }
    }
}
