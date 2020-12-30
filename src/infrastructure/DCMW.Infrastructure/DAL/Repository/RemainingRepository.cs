using Dapper;
using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Entities.Remainings;
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
    public class RemainingRepository : BaseRepository<Remaining>, IRemaininRepository
    {
        public RemainingRepository(IConfiguration config) : base(config, "Remainings") { }

        public async Task<(Remaining, DateTime?)> GetByProduct(Guid productID)
        {
            string sql = @$"SELECT *
                            From Remainings
                            WHERE ProductID = @ProductID";

            var model = default(Remaining);
            DateTime? lastUpdateDate = null;

            using (var connection = Connection)
            {
                var row = await connection.QuerySingleAsync(sql, new { @ProductID = productID });
                if (row != null)
                {
                    model = (Remaining)ExtractModel<Remaining>(row);
                    lastUpdateDate = DateTime.Parse(((IDictionary<string, object>)row)["LastUpdateDate"]?.ToString());
                }
            }

            return (model, lastUpdateDate);
        }

    
    }
}
