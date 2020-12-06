using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Distributors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors
{
    public class SaveNewDistrbutorHandler : IRequestHandler<SaveNewDistrbutorRequest, Result>
    {
        private readonly IDistributorRepository distributorRepository;

        public SaveNewDistrbutorHandler(IDistributorRepository distributorRepository)
        {
            this.distributorRepository = distributorRepository;
        }

        public Task<Result> Handle(SaveNewDistrbutorRequest request, CancellationToken cancellationToken)
        {
            return distributorRepository.Insert(new Distributor (
                Guid.NewGuid(),
                fullname : request.FullName,
                mobile : request.MobileNumber,
                email : request.Email,
                company : request.Company
            ));   
        }
    }
}
