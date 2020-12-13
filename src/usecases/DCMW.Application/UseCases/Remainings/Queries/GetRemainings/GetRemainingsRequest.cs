using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class GetRemainingsRequest : IRequest<GetRemainingsResponse>
    {
        public string SearchWord { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
