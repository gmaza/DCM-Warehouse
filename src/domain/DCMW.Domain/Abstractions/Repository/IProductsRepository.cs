using DCMW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Domain.Abstractions.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByIDs(IEnumerable<Guid> ids);
        Task<IEnumerable<Product>> Filter(string searchWord, int skip, int take);
        Task<int> Count(string searchWord);
    }
}
