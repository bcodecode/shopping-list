using Checkout.ApiServices.ShoppingList.RequestModels;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class ResetDataRequest : BaseOrderItem
    {
        public string Created { get; set; }
    }
}
