using DCMW.Domain.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IDistributorRepository : IRepository<Distributor>
    {
        Task<IEnumerable<Distributor>> Filter(object searchWord, object skip, object take);
        Task<int> Count(string searchWord);
    }
}
