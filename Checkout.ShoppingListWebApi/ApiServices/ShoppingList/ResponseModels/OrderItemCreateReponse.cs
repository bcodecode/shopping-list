using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;

namespace Checkout.ApiServices.Customers.ResponseModels
{
    public class OrderItemCreateReponse : BaseOrderItem
    {
        public string Created { get; set; }
        public Error Error { get; set; }
    }
}
