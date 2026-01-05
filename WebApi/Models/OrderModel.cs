using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public string CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<LineItemModel> LineItems { get; set; }
    }
}
