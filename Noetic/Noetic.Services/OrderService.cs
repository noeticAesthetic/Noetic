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
        IRepository<Product> productContext;

        public OrderService(IRepository<Order> OrderContext, IRepository<Product> ProductContext)
        {
            this.orderContext = OrderContext;
            this.productContext = ProductContext;
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

                // Find Product to reduce Quantity
                Product product = productContext.Find(item.ProductId);
                if (product != null)
                {
                    product.Quantity -= item.Quantity;
                }
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();

            productContext.Commit();
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
