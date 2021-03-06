﻿using DCMW.Common.Models;
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
        public Guid ID { get;  set; }
        public string FullName { get;  set; }
        public string Mobile { get;  set; }
        public string PersonalNumber { get;  set; }
    }
}
