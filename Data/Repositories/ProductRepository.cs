using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDocumentSession _documentSession;

        public ProductRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public Product Get(string name)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            if (name != null)
            {
                query = query.Where($"Name:*{name}*");
            }

            return query.Single();
        }

        public IEnumerable<Product> Get(string name = null, string description = null, double? minPrice = null, double? maxPrice = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            var hasFirstParameter = false;
            if (name != null)
            {
                query = query.Where($"Name:*{name}*");
                hasFirstParameter = true;
            }

            if (description != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Description:*{description}*");
            }

            if (minPrice != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.WhereGreaterThanOrEqual("Price", minPrice.Value);
            }

            if (maxPrice != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereLessThanOrEqual("Price", maxPrice.Value);
            }

            return query.ToList();
        }

        public IEnumerable<Product> Get(double price)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();
            query.WhereEquals("Price", price);
            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<ProductsListIndex>();
        }
    }
}