using Checkout.ApiServices.ShoppingList.RequestModels;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class OrderItemUpdateRequest : BaseOrderItem
    {
        public string Created { get; set; }
    }
}
