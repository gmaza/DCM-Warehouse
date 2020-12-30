using DCMW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IRepository<T>
    {
        Task<Result> Insert(T t);

        Task<Result> Update(T t, DateTime lastUpdateDate);

        Task<(T, DateTime?)> Get(Guid id);

        Task<Result> Delete(Guid id);

        Task<IEnumerable<T>> Filter(string searchWord, int skip, int take);
        Task<int> Count(string searchWord);
    }
}
