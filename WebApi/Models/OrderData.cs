using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            CustomerId = order.CustomerId;
            Status = new EnumData(order.Status);
            TotalAmount = order.TotalAmount;
            OrderDate = order.OrderDate;
            LineItems = order.LineItems?.Select(li => new LineItemData(li)).ToList();
        }

        public string CustomerId { get; set; }
        public EnumData Status { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<LineItemData> LineItems { get; set; }
    }
}
