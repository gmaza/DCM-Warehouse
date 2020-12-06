using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors
{
    public class SaveNewDoctorHandler : IRequestHandler<SaveNewDoctorRequest, Result>
    {
        private readonly IDoctorRepository doctorRepository;

        public SaveNewDoctorHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(SaveNewDoctorRequest request, CancellationToken cancellationToken)
        {
            return await doctorRepository.Insert(new Doctor(Guid.NewGuid(), 
                request.FullName, 
                request.Mobile, 
                request.PersonalNumber));
        }
    }
}
