using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Pickings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Pickings.Commands.AddNewPicking
{
    public class AddNewPickingHandler : IRequestHandler<AddNewPickingRequest, Result>
    {
        private readonly IPickingRepository pickingRepository;

        public AddNewPickingHandler(IPickingRepository pickingRepository)
        {
            this.pickingRepository = pickingRepository;
        }

        public async Task<Result> Handle(AddNewPickingRequest request, CancellationToken cancellationToken)
        {
            var doctor = new PickingDoctor(Guid.NewGuid(), 
                request.DoctorID, 
                request.FullName,
                request.MobileNumber, 
                request.PersonalNumber);

            var lst = request.Products.Select(i => new PickingProduct(Guid.NewGuid(),
                    i.ProductID,
                    i.Name,
                    i.Code,
                    i.Description,
                    i.Quantity,
                    i.Unit
                ));

            return await pickingRepository.Insert(new Picking(Guid.NewGuid(), request.Date, doctor, lst));
        }
    }
}
