using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

namespace Dapper_Exercise
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
       public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int CategoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @price, @categoryID;",
                new {productName = name, price = price, CategoryID = CategoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public void UpdateProductName(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET name = @updatedName WHERE productID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
        }
    }
}
