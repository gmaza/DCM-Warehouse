using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Products;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Infrastructure.DAL.Repository
{
    public class ProductRepository : BaseRepository, IProductsRepository
    {
        public ProductRepository(IConfiguration config) : base(config) { }

        public Task<int> Count(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Filter(string searchWord, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<(Product, DateTime?)> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByIDs(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Product t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
