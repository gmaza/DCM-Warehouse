using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorRequest : IRequest<Result>
    {
        public Guid ID { get; internal set; }
        public string FullName { get; internal set; }
        public string Mobile { get; internal set; }
        public string PersonalNumber { get; internal set; }
    }
}
