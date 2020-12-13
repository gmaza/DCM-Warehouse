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
    public class RemainingRepository : IRemaininRepository
    {
        private readonly IConfiguration _config;

        public RemainingRepository(IConfiguration config)
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

        public Task<int> Count(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Remaining>> Filter(string searchWord, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<(Remaining, DateTime?)> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(Remaining, DateTime)> GetByProduct(Guid productID)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Remaining t)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Remaining t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
