using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Distributors;
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
    public class DistributorRepository : BaseRepository, IDistributorRepository
    {
        public DistributorRepository(IConfiguration config) : base(config) { }

        public Task<int> Count(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Distributor>> Filter(object searchWord, object skip, object take)
        {
            throw new NotImplementedException();
        }

        public Task<(Distributor, DateTime?)> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Distributor t)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Distributor t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
