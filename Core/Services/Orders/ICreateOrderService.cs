using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, string customerId, OrderStatus status, double totalAmount, DateTime orderDate, IEnumerable<LineItem> lineItems);
    }
}
