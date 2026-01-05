using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> Get(string customerId = null, OrderStatus? status = null, DateTime? fromDate = null, DateTime? toDate = null);
        void DeleteAll();
    }
}
