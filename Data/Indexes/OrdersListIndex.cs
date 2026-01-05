using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using System.Linq;

namespace Data.Indexes
{
    public class OrdersListIndex : AbstractIndexCreationTask<Order>
    {
        public OrdersListIndex()
        {
            Map = orders => from order in orders
                           select new
                           {
                               CustomerId = order.CustomerId,
                               Status = order.Status,
                               TotalAmount = order.TotalAmount,
                               OrderDate = order.OrderDate
                           };
            Index(x => x.CustomerId, FieldIndexing.NotAnalyzed);
            Index(x => x.Status, FieldIndexing.NotAnalyzed);
            Sort(x => x.TotalAmount, SortOptions.Double);
            Sort(x => x.OrderDate, SortOptions.String);
        }
    }
}
