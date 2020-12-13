using DCMW.Domain.Pickings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IPickingRepository : IRepository<Picking>
    {
        Task<IEnumerable<Picking>> Filter(string searchWord, int skip, int take);
        Task<int> Count(string searchWord);
    }
}
