using Noetic.Core.Contracts;
using Noetic.Core.Models;
using Noetic.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Noetic.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;

        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public List<Order> GetOrderList()
        {
            return orderContext.Collection().ToList();
        }

        public void UpdateOrder(Order updatedOrder)
        {
            orderContext.Update(updatedOrder);
            orderContext.Commit();
        }
    }
}
