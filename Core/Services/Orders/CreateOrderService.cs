using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, string customerId, OrderStatus status, double totalAmount, DateTime orderDate, IEnumerable<LineItem> lineItems)
        {
            var order = _orderFactory.Create(id);
            _updateOrderService.Update(order, customerId, status, totalAmount, orderDate, lineItems);
            _orderRepository.Save(order);
            return order;
        }
    }
}
