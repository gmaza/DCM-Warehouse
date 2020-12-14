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
    public abstract class BaseRepository
    {
        private readonly IConfiguration _config;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("dcmwconnectionstring"));
            }
        }

        protected T ExtractModel<T>(dynamic r)
        {
            T model = (T)Activator.CreateInstance(typeof(T), true);

            FieldInfo[] fields = model.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            foreach (var field in fields)
            {
                var colName = FirstCharToUpper(field.Name.Remove(0, 1));
                field.SetValue(model, r[colName]);
            }

            return model;
        }

        public string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
    }
}
