using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;

namespace WinFormsApp2
{
    public class DatabaseController
    {
        private readonly IDbConnection _db;

        public DatabaseController(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return _db.Query<T>(sql, param);
        }

        public T QuerySingleOrDefault<T>(string sql, object param = null)
        {
            return _db.QuerySingleOrDefault<T>(sql, param);
        }

        public void Execute(string sql, object param = null)
        {
            _db.Execute(sql, param);
        }
    }
}
