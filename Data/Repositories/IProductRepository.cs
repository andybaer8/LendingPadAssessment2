using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(string name);
        IEnumerable<Product> Get(string name = null, string description = null, double? minPrice = null, double? maxPrice = null);
        IEnumerable<Product> Get(double price);
        void DeleteAll();
    }
}
