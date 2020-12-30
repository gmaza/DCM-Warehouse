using Dapper;
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
    public class ProductRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductRepository(IConfiguration config) : base(config, "Products") { }

        public async Task<IEnumerable<Product>> GetByIDs(IEnumerable<Guid> ids)
        {
            if (ids.Count() == 0)
                return new List<Product>();

            string sql = @"SELECT *
                            From Products
                            WHERE ID in @ids";

            IEnumerable<Product> result;

            using (var connection = Connection)
            {
                var rows = await connection.QueryAsync(sql, new { ids = ids} );
                result = rows.Select(r => (Product)ExtractModel<Product>(r));
            }

            return result;
        }

        protected override string GetComparionsText(string searchWord)
        {
            return $@"Name like {searchWord}";
        }
    }
}
