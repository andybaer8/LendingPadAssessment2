using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private readonly List<LineItem> _lineItems = new List<LineItem>();
        private string _customerId;
        private OrderStatus _status = OrderStatus.Pending;
        private double _totalAmount;
        private DateTime _orderDate;

        public string CustomerId
        {
            get => _customerId;
            private set => _customerId = value;
        }

        public OrderStatus Status
        {
            get => _status;
            private set => _status = value;
        }

        public double TotalAmount
        {
            get => _totalAmount;
            private set => _totalAmount = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public IEnumerable<LineItem> LineItems
        {
            get => _lineItems;
            private set => _lineItems.Initialize(value);
        }

        public void SetCustomerId(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentNullException("Customer ID was not provided.");
            }
            _customerId = customerId;
        }

        public void SetStatus(OrderStatus status)
        {
            _status = status;
        }

        public void SetTotalAmount(double totalAmount)
        {
            if (totalAmount < 0)
            {
                throw new ArgumentException("Total amount cannot be negative.");
            }
            _totalAmount = totalAmount;
        }

        public void SetOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
        }

        public void SetLineItems(IEnumerable<LineItem> lineItems)
        {
            _lineItems.Initialize(lineItems);
        }
    }
}
