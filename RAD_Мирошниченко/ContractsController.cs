
using System.Collections.Generic;
using System.Data;
using Dapper;


namespace WinFormsApp2
{
    class ContractsController
    {
        private readonly IDbConnection _db;

        public ContractsController(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Contract> GetAll()
        {
            return _db.Query<Contract>("SELECT * FROM contracts");
        }

        public Contract GetById(int id)
        {
            return _db.QuerySingleOrDefault<Contract>("SELECT * FROM contracts WHERE id = @Id", new { Id = id });
        }

        public void Add(Contract contract)
        {
            _db.Execute("INSERT INTO contracts (name, start_date, end_date, client_id) VALUES (@Name, @StartDate, @EndDate, @ClientId)", contract);
        }

        public void Update(Contract contract)
        {
            _db.Execute("UPDATE contracts SET name = @Name, start_date = @StartDate, end_date = @EndDate, client_id = @ClientId WHERE id = @Id", contract);
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM contracts WHERE id = @Id", new { Id = id });
        }

        public IEnumerable<Contract> Search(string searchTerm)
        {
            return _db.Query<Contract>("SELECT * FROM contracts WHERE name LIKE @SearchTerm", new { SearchTerm = $"%{searchTerm}%" });
        }
    }
}
