using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;

namespace WinFormsApp2
{
    public class PaymentController
    {
        private readonly IDbConnection _db;

        public PaymentController(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _db.Query<Payment>("SELECT * FROM payments");
        }

        public Payment GetById(int id)
        {
            return _db.QuerySingle<Payment>("SELECT * FROM payments WHERE id = @Id", new { Id = id });
        }

        public void Add(Payment payment)
        {
            _db.Execute("INSERT INTO payments (amount, date, contract_id) VALUES (@Amount, @Date, @ContractId)", payment);
        }

        public void Update(Payment payment)
        {
            _db.Execute("UPDATE payments SET amount = @Amount, date = @Date, contract_id = @ContractId WHERE id = @Id", payment);
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM payments WHERE id = @Id", new { Id = id });
        }
    }
}
