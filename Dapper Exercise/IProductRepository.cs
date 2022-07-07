using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_Exercise
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string name, double price, int CategoryID);
    }
}
