using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors
{
    public class SaveNewDoctorRequest : IRequest<Result>
    {
        public string FullName { get;  set; }
        public string Mobile { get;  set; }
        public string PersonalNumber { get;  set; }
    }
}
