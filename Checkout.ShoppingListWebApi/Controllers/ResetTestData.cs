using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ShoppingListWebApi.ApiServices.ShoppingList;
using System;
using System.Web.Http;

namespace Checkout.ShoppingListWebApi.Controllers
{
    public class ResetTestDataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Reset()
        {
            MockData.OrderItems.Clear();
            MockData.OrderItems.Add(new BaseOrderItem() { Drink = MockData.Pepsi, Quantity = 3, CreateDateTime = DateTime.Now });
            MockData.OrderItems.Add(new BaseOrderItem() { Drink = MockData.Beer, Quantity = 1, CreateDateTime = DateTime.Now.AddMinutes(-10) });
            MockData.OrderItems.Add(new BaseOrderItem() { Drink = MockData.Fanta, Quantity = 1, CreateDateTime = DateTime.Now.AddMinutes(-15) });

            return Ok();
        }
    }
}
