using Dapper;
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
    public class DistributorRepository : BaseRepository<Distributor>, IDistributorRepository
    {
        public DistributorRepository(IConfiguration config) : base(config, "Distributors") { }

 
        protected override string GetComparionsText(string searchWord)
        {
            return $@"FullName like {searchWord}";
        }
    }
}
