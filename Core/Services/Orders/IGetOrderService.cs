using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetOrders(string customerId = null, OrderStatus? status = null, DateTime? fromDate = null, DateTime? toDate = null);
    }
}
