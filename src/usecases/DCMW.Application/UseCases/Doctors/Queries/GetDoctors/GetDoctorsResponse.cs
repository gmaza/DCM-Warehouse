using DCMW.Domain.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Application.UseCases.Doctors.Queries.GetDoctors
{
    public class GetDoctorsResponse
    {
        public IEnumerable<Doctor> Items { get; internal set; }
        public int Quantity { get; internal set; }
    }
}
