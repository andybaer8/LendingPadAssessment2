using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDocumentSession _documentSession;

        public OrderRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Order> Get(string customerId = null, OrderStatus? status = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrdersListIndex>();

            var hasFirstParameter = false;
            if (customerId != null)
            {
                query = query.WhereEquals("CustomerId", customerId);
                hasFirstParameter = true;
            }

            if (status != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.WhereEquals("Status", (int)status);
            }

            if (fromDate != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.WhereGreaterThanOrEqual("OrderDate", fromDate.Value);
            }

            if (toDate != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereLessThanOrEqual("OrderDate", toDate.Value);
            }

            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<OrdersListIndex>();
        }
    }
}
