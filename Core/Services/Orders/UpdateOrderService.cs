using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, string customerId, OrderStatus status, double totalAmount, DateTime orderDate, IEnumerable<LineItem> lineItems)
        {
            order.SetCustomerId(customerId);
            order.SetStatus(status);
            order.SetTotalAmount(totalAmount);
            order.SetOrderDate(orderDate);
            order.SetLineItems(lineItems);
        }
    }
}
