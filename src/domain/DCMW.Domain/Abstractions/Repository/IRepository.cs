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
        Result Insert(T t);

        Result Update(T t, DateTime lastUpdateDate);

        (T, DateTime?) Get(Guid id);

        Result Delete(Guid id);
    }
}
