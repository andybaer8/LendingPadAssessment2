using System;

namespace WebApi.Models.Orders
{
    public class LineItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }
    }
}
