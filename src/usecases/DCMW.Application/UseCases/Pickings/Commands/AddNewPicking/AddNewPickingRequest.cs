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
        public Guid DoctorID { get; internal set; }
        public string FullName { get; internal set; }
        public string MobileNumber { get; internal set; }
        public string PersonalNumber { get; internal set; }
        public DateTime Date { get; internal set; }
        public IEnumerable<AddNewPickingProductRequest> Products { get; internal set; }
    }

    public class AddNewPickingProductRequest
    {
        public Guid ProductID{ get; internal set; }
        public decimal Quantity { get; internal set; }
        public string Unit { get; internal set; }
    }
}
