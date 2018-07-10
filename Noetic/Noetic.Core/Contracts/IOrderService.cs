using Noetic.Core.Models;
using Noetic.Core.ViewModels;
using System.Collections.Generic;

namespace Noetic.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updatedOrder);
    }
}
