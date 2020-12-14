using DCMW.Common.Models;
using DCMW.Domain.Abstractions.Repository;
using DCMW.Domain.Pickings;
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
    public class PickingRepository : BaseRepository, IPickingRepository
    {
        public PickingRepository(IConfiguration config) : base(config) { }

        public Task<int> Count(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Picking>> Filter(string searchWord, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<(Picking, DateTime?)> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Picking t)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Picking t, DateTime lastUpdateDate)
        {
            throw new NotImplementedException();
        }
    }
}
