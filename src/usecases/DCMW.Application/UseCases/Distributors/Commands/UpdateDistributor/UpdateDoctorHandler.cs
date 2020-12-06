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

namespace DCMW.Application.UseCases.Distrbutors.Commands.UpdateDistrbutor
{
    public class UpdateDistrbutorHandler : IRequestHandler<UpdateDistrbutorRequest, Result>
    {
        private readonly IDistributorRepository distributorRepository;

        public UpdateDistrbutorHandler(IDistributorRepository distributorRepository)
        {
            this.distributorRepository = distributorRepository;
        }

        public async Task<Result> Handle(UpdateDistrbutorRequest request, CancellationToken cancellationToken)
        {
            var (distributor, updateDate) = await distributorRepository.Get(request.ID);

            distributor.ChangeCompanyName(request.CompanyName)
                        .ChangeEmail(request.Email)
                        .ChangeFullName(request.FullName)
                        .CHangeMobile(request.Mobile);

            return await distributorRepository.Update(distributor, updateDate.Value);
        }
    }
}
