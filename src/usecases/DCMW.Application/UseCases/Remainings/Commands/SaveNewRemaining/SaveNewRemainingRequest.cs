using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class SaveNewRemainingRequest : IRequest<Result>
    {
        public decimal Amount { get; set; }
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
