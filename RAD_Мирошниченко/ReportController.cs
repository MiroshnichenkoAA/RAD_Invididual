using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;

namespace WinFormsApp2
{
    public class ReportController 
    { 
        private readonly IDbConnection _db; 
        public ReportController(string connectionString) 
        { 
            _db = new NpgsqlConnection(connectionString);
        } 
        public IEnumerable<Report> GetAll() 
        { 
            return _db.Query<Report>("SELECT * FROM reports"); 
        } 
        public Report GetById(int id) 
        { 
            return _db.QuerySingle<Report>("SELECT * FROM reports WHERE id = @Id", new { Id = id });
        }
        public void Add(Report report) 
        { 
            _db.Execute("INSERT INTO reports (name, date, content) VALUES (@Name, @Date, @Content)", report);
        }
        public void Update(Report report) 
        { 
            _db.Execute("UPDATE reports SET name = @Name, date = @Date, content = @Content WHERE id = @Id", report);
        } 
        public void Delete(int id) 
        { 
            _db.Execute("DELETE FROM reports WHERE id = @Id", new { Id = id });
        } 
    }
}
