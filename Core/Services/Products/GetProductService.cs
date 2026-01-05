using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public Product GetProduct(string name)
        {
            return _productRepository.Get(name);
        }

        public IEnumerable<Product> GetProducts(string name = null, string description = null, double? minPrice = null, double? maxPrice = null)
        {
            return _productRepository.Get(name, description, minPrice, maxPrice);
        }

        public IEnumerable<Product> GetProductsByPrice(double price)
        {
            return _productRepository.Get(price);
        }
    }
}