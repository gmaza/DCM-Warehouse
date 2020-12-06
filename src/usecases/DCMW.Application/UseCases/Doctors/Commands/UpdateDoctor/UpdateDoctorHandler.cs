using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorRequest, Result>
    {
        private readonly IDoctorRepository doctorRepository;

        public UpdateDoctorHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(UpdateDoctorRequest request, CancellationToken cancellationToken)
        {
            var (doctor, updateDate) = await doctorRepository.Get(request.ID);

            doctor.ChangeFullName(request.FullName)
                .ChangeMobile(request.Mobile)
                .ChangePersonalNumber(request.PersonalNumber);

            return await doctorRepository.Update(doctor, updateDate.Value);
        }
    }
}
