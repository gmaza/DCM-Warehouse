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
    public class ProductRepository : IProductsRepository
    {
        private readonly IConfiguration _config;

        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("dcmwconnectionstring"));
            }
        }

        public Result Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public (Product, DateTime?) Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Result Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public Result Update(Product t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
