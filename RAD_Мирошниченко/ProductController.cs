using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper;

namespace WinFormsApp2
{
    public class ProductController
    {
        private readonly IDbConnection _db;

        public ProductController(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Query<Product>("SELECT * FROM products");
        }

        public Product GetById(int id)
        {
            return _db.QuerySingle<Product>("SELECT * FROM products WHERE id = @Id", new { Id = id });
        }

        public void Add(Product product)
        {
            _db.Execute("INSERT INTO products (name, price, quantity) VALUES (@Name, @Price, @Quantity)", product);
        }

        public void Update(Product product)
        {
            _db.Execute("UPDATE products SET name = @Name, price = @Price, quantity = @Quantity WHERE id = @Id", product);
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM products WHERE id = @Id", new { Id = id });
        }
    }
}
