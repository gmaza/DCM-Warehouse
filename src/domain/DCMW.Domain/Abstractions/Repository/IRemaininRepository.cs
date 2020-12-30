using DCMW.Domain.Entities.Remainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IRemaininRepository : IRepository<Remaining>
    {
        Task<(Remaining, DateTime?)> GetByProduct(Guid productID);
        Task<IEnumerable<Remaining>> Filter(string searchWord, int skip, int take);
        Task<int> Count(string searchWord);
    }
}
