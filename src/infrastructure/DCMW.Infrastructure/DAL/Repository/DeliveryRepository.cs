using Dapper;
using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Deliveries;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DCMW.Infrastructure.DAL.Repository
{
    public class DeliveryRepository : BaseRepository, IDeliveryRepository
    {
        public DeliveryRepository(IConfiguration config) : base(config) {}

        public async Task<int> Count(string searchWord)
        {
            string sql = @"SELECT Count(ID) 
                            From [Deliveries]
                            WHERE DistributorName like @search
                                                OR DistributorMobileNumber like @search
                                                OR DistributorEmail like @search
                                                OR DistributorCompanyName like @search";

            int quantity;
            using (var connection = Connection)
            {
                quantity = await connection.QueryFirstAsync<int>(sql, new { search = $"%{searchWord}%" });
            }

            return quantity;
        }

        public async Task<Result> Delete(Guid id)
        {
            string sql = @"DELETE FROM Deliveries
                            WHERE ID = @ID";

            int effectedRows;
            using (var connection = Connection)
            {
                effectedRows = await connection.ExecuteAsync(sql, new { ID = id });
            }

            return effectedRows == 0 ? new Result(false, "ასეთი ჩანაწერი არ მოიძებნა") : Result.CreateSuccessReqest();
        }

        public async Task<IEnumerable<Delivery>> Filter(string searchWord, int skip, int take)
        {
            string sql = @"SELECT *
                            From [Deliveries]
                            WHERE DistributorName like @search
                                                OR DistributorMobileNumber like @search
                                                OR DistributorEmail like @search
                                                OR DistributorCompanyName like @search";

            IEnumerable<Delivery> result;

            using (var connection = Connection)
            {
                var rows = await connection.QueryAsync(sql, new { search = $"%{searchWord}%" });
                result = rows.Select(r => (Delivery)ExtractModel<Delivery>(r));
            }

            return result;
        }

        public async Task<(Delivery, DateTime?)> Get(Guid id)
        {
            string sql = @"SELECT *
                            From [Deliveries]
                            WHERE ID = @ID";

            Delivery result = null;
            DateTime? lastUpdateDate = null;

            using (var connection = Connection)
            {
                var row = await connection.QuerySingleAsync(sql, new { ID = id });
                if (row != null)
                {
                    result = ExtractModel<Delivery>(row);
                    lastUpdateDate = DateTime.Parse(row.LastUpdateDate);
                }
            }

            return (result, lastUpdateDate);
        }

        public Task<Result> Insert(Delivery t)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Delivery t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
