using BusinessEntities;
using Raven.Abstractions.Data;
using System;
using System.Collections.Generic;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        Product GetProduct(string name);
        IEnumerable<Product> GetProducts(string name = null, string description = null, double? minPrice = null, double? maxPrice = null);
        IEnumerable<Product> GetProductsByPrice(double price);
    }
}