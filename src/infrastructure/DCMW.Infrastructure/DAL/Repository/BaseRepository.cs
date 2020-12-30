using Dapper;
using DCMW.Common.Models;
using DCMW.Domain;
using DCMW.Domain.Abstractions.Repository;
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
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IConfiguration _config;
        private readonly string _tablename;

        public BaseRepository(IConfiguration config, string tablename)
        {
            _config = config;
            _tablename = tablename;
        }

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("dcmwconnectionstring"));
            }
        }

        public async Task<Result> Delete(Guid id)
        {
            string sql = @$"DELETE FROM {_tablename}
                            WHERE ID = @ID";

            int effectedRows;
            using (var connection = Connection)
            {
                effectedRows = await connection.ExecuteAsync(sql, new { ID = id });
            }

            return effectedRows == 0 ? new Result(false, "ასეთი ჩანაწერი არ მოიძებნა") : Result.CreateSuccessReqest();
        }

        public async Task<(T, DateTime?)> Get(Guid id)
        {
            string sql = @$"SELECT *
                            From {_tablename}
                            WHERE ID = @ID";

            T model = default(T);
            DateTime? lastUpdateDate = null;

            using (var connection = Connection)
            {
                var row = await connection.QuerySingleAsync(sql, new { ID = id });
                if (row != null)
                {
                    model = ExtractModel<T>(row);
                    lastUpdateDate = DateTime.Parse(((IDictionary<string, object>)row)["LastUpdateDate"]?.ToString());
                }
            }

            return (model, lastUpdateDate);
        }

        public virtual async Task<Result> Insert(T model)
        {
            using var connection = Connection;
            var resp = await Insert(model, connection, _tablename);
            if (resp.IsSuccess)
                model.DispatchDomainEvents();
            return resp;
        }

        protected virtual async Task<Result> Insert<R>(R model, IDbConnection connection, string tableName = null, IDbTransaction tran = null, params Field[] additionalFields)
        {
            var dbArgs = GetParametersWithValues(model);
            dbArgs.Add("LastUpdateDate", DateTime.Now);
            var fields = GetFields(model);

            if (additionalFields != null && additionalFields.Count() != 0)
            {
                foreach (var f in additionalFields)
                    dbArgs.Add(f.Key, f.Value);

                fields.AddRange(additionalFields);
            }

            var fieldNames = string.Join(", ", fields.Select(f => f.Key));
            var fieldParameters = string.Join(", ", fields.Select(f => $"@{f.Key}"));

            string sqlQuery = @$"INSERT INTO {tableName ?? _tablename}
                                    ({fieldNames}, LastUpdateDate)
                             values ({fieldParameters}, @LastUpdateDate)";


            await connection.ExecuteAsync(sqlQuery, dbArgs, tran);

            return Result.CreateSuccessReqest();
        }

        private string GetFieldName<R>(R model, FieldInfo f, string pred = "")
        {
            if (f.GetValue(model) is BaseEntity)
            {
                List<FieldInfo> fields = GetModelFieldNames(f.GetValue(model));
                var fieldNames = string.Join($", ", fields.Select(r => $"{pred}{FirstCharToUpper(f.Name.Remove(0, 1))}{GetFieldName(f.GetValue(model), r)}"));
                return fieldNames;
            }
            else if (f.GetValue(model) == null
              || (!f.GetValue(model).GetType().IsPrimitive
              && !f.GetValue(model).GetType().Equals(typeof(string))
              && !f.GetValue(model).GetType().Equals(typeof(Guid))
              && !f.GetValue(model).GetType().Equals(typeof(DateTime))))
            {
                return null;
            }
            return FirstCharToUpper(f.Name.Remove(0, 1));
        }

        protected record Field(string Key, object Value) { }

        private List<Field> GetFields<R>(R model)
        {
            var result = new List<Field>();

            var fieldNames = GetModelFieldNames(model);

            foreach (var f in fieldNames)
            {
                var capializedFieldName = FirstCharToUpper(f.Name.Remove(0, 1));

                var value = f.GetValue(model);

                if (value is BaseEntity)
                {
                    var innerFieldNames = GetFields(value);
                    var innerFieldsWithValues = innerFieldNames.Select(s => new Field($"{capializedFieldName}{s.Key}", s.Value));
                    result.AddRange(innerFieldsWithValues);
                }
                else if (value != null
                  && (value.GetType().IsPrimitive
                  || value.GetType().Equals(typeof(string))
                  || value.GetType().Equals(typeof(Guid))
                  || value.GetType().Equals(typeof(decimal))
                  || value.GetType().Equals(typeof(DateTime))))
                {
                    result.Add(new Field(capializedFieldName, value));
                }
            }

            return result;
        }

        private static List<FieldInfo> GetModelFieldNames<R>(R model)
        {
            var fields = model.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance)
                         .ToList();

            fields.AddRange(model.GetType().BaseType.GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance));
            return fields;
        }

        public async Task<Result> Update(T t, DateTime lastUpdateDate)
        {
            var dbArgs = GetParametersWithValues(t);
            dbArgs.Add("LastUpdateDate", DateTime.Now);
            var fields = GetFields(t);

            var setValuesText = string.Join(", ", fields.Select(f => $"{f.Key} = @{f.Key}"));

            string sqlQuery = @$"UPDATE {_tablename} 
                                SET {setValuesText}, 
                                    LastUpdateDate = @LastUpdateDate
                                where ID = @ID";

            using (var connection = Connection)
            {
                dbArgs.Add("LastUpdateDate", DateTime.Now);

                await connection.ExecuteAsync(sqlQuery, dbArgs);
            }

            return Result.CreateSuccessReqest();
        }

        public async virtual Task<IEnumerable<T>> Filter(string searchWord, int skip, int take)
        {
            string comparesText = GetComparionsText("@search");

            string sql = @$"SELECT *
                            From {_tablename}
                            WHERE {comparesText}";

            IEnumerable<T> result;

            using (var connection = Connection)
            {
                var rows = await connection.QueryAsync(sql, new { search = $"%{searchWord}%" });
                result = rows.Select(r => (T)ExtractModel<T>(r));
            }

            return result;
        }

        public async Task<int> Count(string searchWord)
        {
            string comparesText = GetComparionsText("@search");
            string sql = @$"SELECT Count(ID) 
                            FROM {_tablename}
                            WHERE {comparesText}";

            int quantity;
            using (var connection = Connection)
            {
                quantity = await connection.QueryFirstAsync<int>(sql, new { search = $"%{searchWord}%" });
            }

            return quantity;
        }

        virtual protected string GetComparionsText(string searchWord)
        {
            var fiels = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(w => w.FieldType == typeof(string))
                .Select(f => $"{FirstCharToUpper( f.Name.Remove(0,1))} like {searchWord}");
            return string.Join(" OR ", fiels);
        }

    virtual protected DynamicParameters GetParametersWithValues<R>(R model)
        {
            var dbArgs = new DynamicParameters();

            var fields = GetFields(model);

            foreach (var field in fields)
            {
                dbArgs.Add(field.Key, field.Value);
            }

            return dbArgs;
        }

        virtual protected R ExtractModel<R>(dynamic r, string prefix = "")
        {
            R model = (R)Activator.CreateInstance(typeof(R), true);

            var fields = GetModelFieldNames(model);

            var values = ((IDictionary<string, object>)r);
            foreach (var field in fields)
            {
                if(field.FieldType.BaseType == typeof(BaseEntity))
                {
                    MethodInfo ExtractModel = this.GetType().GetMethod("ExtractModel", BindingFlags.Instance | BindingFlags.NonPublic);
                    MethodInfo genericFetchMethod = ExtractModel.MakeGenericMethod(field.FieldType);
                    var dt = genericFetchMethod.Invoke(this, new object[] { r, FirstCharToUpper(field.Name.Remove(0, 1)) });
                    field.SetValue(model,dt );
                }

                var colName = FirstCharToUpper(field.Name.Remove(0, 1));
                var val = values[$"{prefix}{colName}"];
                if (val == null)
                    continue;
                field.SetValue(model, val);
            }

            return model;
        }

        protected string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            "id" => "ID",
            _ => input.First().ToString().ToUpper() + input.Substring(1),
        };
    }
}
