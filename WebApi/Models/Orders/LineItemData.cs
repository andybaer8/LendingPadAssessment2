using System;
using BusinessEntities;
using WebApi.Models.Products;

namespace WebApi.Models.Orders
{
    public class LineItemData : IdObjectData
    {
        public LineItemData(LineItem lineItem) : base(lineItem)
        {
            ProductId = lineItem.ProductId;
            Quantity = lineItem.Quantity;
            PriceAtPurchase = lineItem.PriceAtPurchase;

            if (lineItem.Product != null)
            {
                Product = new ProductData(lineItem.Product);
            }
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }
        public ProductData Product { get; set; }
    }
}
