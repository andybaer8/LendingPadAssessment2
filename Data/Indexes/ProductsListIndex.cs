using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Data.Indexes
{
    public class ProductsListIndex : AbstractIndexCreationTask<Product>
    {
        public ProductsListIndex()
        {
            Map = products => from product in products
                              select new
                              {
                                  Name = product.Name,
                                  Description = product.Description,
                                  Price = product.Price
                              };
            Index(x => x.Name, FieldIndexing.Analyzed);
            Index(x => x.Description, FieldIndexing.Analyzed);
            Sort(x => x.Price, SortOptions.Double);
        }
    }
}
