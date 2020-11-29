using DCMW.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Distrbutors
{
    public class SaveNewDistrbutorRequest : IRequest<Result>
    {
        private string _name;

        private string _code;

        private string _description;

        private decimal _defaultPrice;

        public string Name { get => _name; set => _name = value; }
        public string Code { get => _code; set => _code = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal DefaultPrice { get => _defaultPrice; set => _defaultPrice = value; }
    }
}
