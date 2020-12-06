using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors.Commands.UpdateDistrbutor
{
    public class UpdateDistrbutorRequest : IRequest<Result>
    {
        public Guid ID { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Email { get; internal set; }
        public string FullName { get; internal set; }
        public string Mobile { get; internal set; }
    }
}
