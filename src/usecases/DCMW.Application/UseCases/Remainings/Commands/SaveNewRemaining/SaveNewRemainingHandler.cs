﻿using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class SaveNewRemainingHandler : IRequestHandler<SaveNewRemainingRequest, Result>
    {
        public Task<Result> Handle(SaveNewRemainingRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}