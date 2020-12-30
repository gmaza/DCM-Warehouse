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
    public class PickingRepository : BaseRepository<Picking>, IPickingRepository
    {
        public PickingRepository(IConfiguration config) : base(config, "Pickings") { }

        protected override string GetComparionsText(string searchWord)
        {
            return $@"FullName like {searchWord}";
        }
    }
}
