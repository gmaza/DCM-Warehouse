using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors
{
    public class SaveNewDistrbutorRequest : IRequest<Result>
    {
        public string Company { get;  set; }
        public string Email { get;  set; }
        public string FullName { get;  set; }
        public string MobileNumber { get;  set; }
    }
}
