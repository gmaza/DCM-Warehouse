using DCMW.Domain.Abstractions.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Queries.GetDoctors
{
    public class GetDoctorsHandler : IRequestHandler<GetDoctorsRequest, GetDoctorsResponse>
    {
        private readonly IDoctorRepository doctorRepository;

        public GetDoctorsHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<GetDoctorsResponse> Handle(GetDoctorsRequest request, CancellationToken cancellationToken)
        {
            var items = await doctorRepository.Filter(request.SearchWord, request.Skip, request.Take);
            var quantiy = await doctorRepository.Count(request.SearchWord);

            return new GetDoctorsResponse
            {
                Items = items,
                Quantity = quantiy
            };
        }
    }
}
