using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Factories;
using Core.Services.Orders;
using Data.Repositories;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<LineItem> _lineItemFactory;
        private readonly IProductRepository _productRepository;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService, IIdObjectFactory<LineItem> lineItemFactory, IProductRepository productRepository)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
            _lineItemFactory = lineItemFactory;
            _productRepository = productRepository;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var lineItems = CreateLineItems(model.LineItems);
            var order = _createOrderService.Create(orderId, model.CustomerId, model.Status, model.TotalAmount, model.OrderDate, lineItems);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            var lineItems = CreateLineItems(model.LineItems);
            _updateOrderService.Update(order, model.CustomerId, model.Status, model.TotalAmount, model.OrderDate, lineItems);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, string customerId = null, OrderStatus? status = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var orders = _getOrderService.GetOrders(customerId, status, fromDate, toDate)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }

        private System.Collections.Generic.List<LineItem> CreateLineItems(System.Collections.Generic.IEnumerable<LineItemModel> lineItemModels)
        {
            var lineItems = new System.Collections.Generic.List<LineItem>();
            if (lineItemModels != null)
            {
                foreach (var lineItemModel in lineItemModels)
                {
                    var lineItem = _lineItemFactory.Create(Guid.NewGuid());
                    var product = _productRepository.Get(lineItemModel.ProductId);
                    if (product != null)
                    {
                        lineItem.SetProduct(product);
                    }
                    else
                    {
                        lineItem.SetProductId(lineItemModel.ProductId);
                    }
                    lineItem.SetQuantity(lineItemModel.Quantity);
                    lineItem.SetPriceAtPurchase(lineItemModel.PriceAtPurchase);
                    lineItems.Add(lineItem);
                }
            }
            return lineItems;
        }
    }
}
