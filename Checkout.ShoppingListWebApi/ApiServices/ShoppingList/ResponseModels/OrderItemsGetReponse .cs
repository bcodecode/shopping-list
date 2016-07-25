using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using System.Collections.Generic;

namespace Checkout.ApiServices.Customers.ResponseModels
{
    public class OrderItemsGetReponse
    {
        public string Created { get; set; }
        public List<BaseOrderItem> OrderItems { get; set; }
        public Error Error { get; set; }
    }
}
