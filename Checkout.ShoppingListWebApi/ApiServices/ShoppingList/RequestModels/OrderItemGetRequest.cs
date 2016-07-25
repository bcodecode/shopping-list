using Checkout.ApiServices.ShoppingList.RequestModels;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class OrderItemCreateRequest : BaseOrderItem
    {
        public string Created { get; set; }
    }
}
