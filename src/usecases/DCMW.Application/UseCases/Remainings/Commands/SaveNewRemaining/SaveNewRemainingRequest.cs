using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Remainings
{
    public class SaveNewRemainingRequest : IRequest<Result>
    {
        private decimal _amount;

        private Guid _productID;

        private string _name;

        private string _code;

        private string _description;


        public Guid ProductID
        {
            get => _productID;
        }

        public string Name
        {
            get => _name;
        }

        public string Code
        {
            get => _code;
        }

        public string Description
        {
            get => _description;
        }


        public decimal Amount
        {
            get { return _amount; }
        }
    }
}
