using Noetic.Core.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace Noetic.Core.Contracts
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
        void ClearBasket(HttpContextBase httpContext);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
    }
}
