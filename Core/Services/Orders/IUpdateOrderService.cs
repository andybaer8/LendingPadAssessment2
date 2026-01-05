using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, string customerId, OrderStatus status, double totalAmount, DateTime orderDate, IEnumerable<LineItem> lineItems);
    }
}
