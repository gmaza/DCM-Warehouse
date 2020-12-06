using DCMW.Domain.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> Filter(string searchWord, int skip, int take);
        Task<int> Count(string searchWord);
    }
}
