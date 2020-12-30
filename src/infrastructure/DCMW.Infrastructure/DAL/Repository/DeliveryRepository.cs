using Dapper;
using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Deliveries;
using DCMW.Infrastructure.DAL.DomainEvents;
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
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(IConfiguration config) : base(config, "Deliveries") {}

        protected override string GetComparionsText(string searchWord)
        {
            return $@"DistributorFullName like {searchWord}
                        OR DistributorMobileNumber like {searchWord}
                        OR DistributorEmail like {searchWord}
                        OR DistributorCompanyName like {searchWord}";
        }

        public override async Task<Result> Insert(Delivery delivery)
        {
            using var connection = Connection;
            connection.Open();
            using var trans = connection.BeginTransaction();

            try
            {
                await Insert(delivery, connection, "Deliveries", trans);
                foreach (var product in delivery.Products)
                {
                    await Insert(product, connection, "DeliveryProducts", trans, new Field("DeliveryID", delivery.ID));
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new Result(false, ex.Message);
            }
            delivery.DispatchDomainEvents();
            return Result.CreateSuccessReqest();
        }

        public override async Task<IEnumerable<Delivery>> Filter(string searchWord, int skip, int take)
        {
            var deliveries = (await base.Filter(searchWord, skip, take)).ToList();

            using var conn = Connection;

            var query = $@"select * from DeliveryProducts where DeliveryID in @DeliveryIDs";

            var rows = await conn.QueryAsync(query, new { DeliveryIDs = deliveries.Select(d => d.ID) });

            var deliveryProducts = rows.Select(t => new { ID = (Guid)t.DeliveryID, Products = (DeliveryProduct)ExtractModel<DeliveryProduct>(t) });

            for (int i = 0; i < deliveries.Count(); i++)
            {
                var id = deliveries[i].ID;
                var products = deliveryProducts.Where(d => d.ID.CompareTo(id) == 0).Select(d => d.Products);
                deliveries[i].AddProducts(products);
            }

            return deliveries;
        }
    }
}
