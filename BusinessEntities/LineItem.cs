using System;

namespace BusinessEntities
{
    public class LineItem : IdObject
    {
        private int _quantity;
        private double _priceAtPurchase;
        private Product _product;
        private Guid _productId;

        public Product Product
        {
            get => _product;
            private set => _product = value;
        }

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }

        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }

        public double PriceAtPurchase
        {
            get => _priceAtPurchase;
            private set => _priceAtPurchase = value;
        }

        public void SetProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product was not provided.");
            }
            _product = product;
            _productId = product.Id;
        }

        public void SetProductId(Guid productId)
        {
            _productId = productId;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            _quantity = quantity;
        }

        public void SetPriceAtPurchase(double priceAtPurchase)
        {
            if (priceAtPurchase < 0)
            {
                throw new ArgumentException("Price at purchase cannot be negative.");
            }
            _priceAtPurchase = priceAtPurchase;
        }
    }
}
