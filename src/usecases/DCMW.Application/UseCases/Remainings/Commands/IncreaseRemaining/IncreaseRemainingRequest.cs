using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class IncreaseRemainingRequest : IRequest<Result>
    {
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
    }
}
