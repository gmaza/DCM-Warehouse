using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Deliveries
{
    public class AddNewDeliveryRequest : IRequest<Result>
    {
        public Guid DistributorID { get; set; }
        public DateTime Date { get; set; }
        public List<AddNewDeliveryproduct> Products { get; set; }
    }

    public class AddNewDeliveryproduct
    {
        public Guid ProductID { get; set; }
        public decimal Amoount { get; set; }
        public string Unit { get; internal set; }
    }
}
