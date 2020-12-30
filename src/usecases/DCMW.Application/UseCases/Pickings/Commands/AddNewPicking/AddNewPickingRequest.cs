using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Commands.AddNewPicking
{
    public class AddNewPickingRequest : IRequest<Result>
    {
        public Guid DoctorID { get;  set; }
        public string FullName { get;  set; }
        public string MobileNumber { get;  set; }
        public string PersonalNumber { get;  set; }
        public DateTime Date { get; internal set; }
        public IEnumerable<AddNewPickingProductRequest> Products { get;  set; }
    }

    public class AddNewPickingProductRequest
    {
        public Guid ProductID{ get;  set; }
        public decimal Quantity { get;  set; }
        public string Unit { get;  set; }
    }
}
