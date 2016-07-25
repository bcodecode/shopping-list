using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ShoppingListWebApi.ApiServices.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Checkout.ShoppingListWebApi.Controllers
{
    public class OrderItemController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateOrderItem(OrderItemCreateRequest orderItemCreateRequest)
        {
            if (!DrinkIsAvailable(orderItemCreateRequest.Drink.Name))
            {
                return Ok(
                    new OrderItemCreateReponse()
                    {
                        Drink = orderItemCreateRequest.Drink,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.NotAvailableDrink
                    }
                );
            }

            if (MockData.OrderItems.Any(o => o.Drink.Name.Equals(orderItemCreateRequest.Drink.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return Ok(
                    new OrderItemCreateReponse()
                    {
                        Drink = orderItemCreateRequest.Drink,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.DrinkAlreadyOrdered
                    }
                );
            }

            MockData.OrderItems.Add(
                new BaseOrderItem() {
                    Drink = orderItemCreateRequest.Drink,
                    Quantity = orderItemCreateRequest.Quantity,
                    CreateDateTime = DateTime.Now
                });

            return Ok(
                new OrderItemCreateReponse()
                {
                    Drink = orderItemCreateRequest.Drink,
                    Quantity = orderItemCreateRequest.Quantity,
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        [HttpPut]
        public IHttpActionResult UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            if (!DrinkIsAvailable(orderItemUpdateRequest.Drink.Name))
            {
                return Ok(
                    new OrderItemUpdateReponse()
                    {
                        Drink = orderItemUpdateRequest.Drink,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.NotAvailableDrink
                    }
                );
            }

            var orderItem = MockData.OrderItems.FirstOrDefault(o => o.Drink.Name.Equals(orderItemUpdateRequest.Drink.Name, StringComparison.CurrentCultureIgnoreCase));

            if (orderItem == default(BaseOrderItem))
            {
                return Ok(
                    new OrderItemUpdateReponse()
                    {
                        Drink = orderItemUpdateRequest.Drink,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.DrinkHasNotBeenOrderedYet
                    }
                );
            }

            orderItem.Quantity = orderItemUpdateRequest.Quantity;

            return Ok(
                new OrderItemUpdateReponse()
                {
                    Drink = orderItem.Drink,
                    Quantity = orderItem.Quantity,
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        [HttpDelete]
        public IHttpActionResult RemoveOrderItem(string id)
        {
            if (!DrinkIsAvailable(id))
            {
                return Ok(
                    new OrderItemRemoveReponse()
                    {
                        Drink = null,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.NotAvailableDrink
                    }
                );
            }

            var orderItem = MockData.OrderItems.FirstOrDefault(o => o.Drink.Name.Equals(id, StringComparison.CurrentCultureIgnoreCase));

            if (orderItem == default(BaseOrderItem))
            {
                return Ok(
                    new OrderItemRemoveReponse()
                    {
                        Drink = null,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.DrinkHasNotBeenOrderedYet
                    }
                );
            }

            MockData.OrderItems.Remove(orderItem);

            return Ok(
                new OrderItemRemoveReponse()
                {
                    Drink = orderItem.Drink,
                    Quantity = 0,
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        [HttpGet]
        public IHttpActionResult GetOrderItem(string id)
        {
            var orderItem = MockData.OrderItems.FirstOrDefault(o => o.Drink.Name.Equals(id, StringComparison.CurrentCultureIgnoreCase));

            if (orderItem == default(BaseOrderItem))
            {
                return Ok(
                    new OrderItemGetReponse()
                    {
                        Drink = null,
                        Quantity = 0,
                        Created = GetCurrentDateTimeString(),
                        Error = Errors.DrinkHasNotBeenOrderedYet
                    }
                );
            }
            
            return Ok(
                new OrderItemGetReponse()
                {
                    Drink = orderItem.Drink,
                    Quantity = orderItem.Quantity,
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        private static bool DrinkIsAvailable(string drinkName)
        {
            return MockData.AvailableDrinks.Any(d => d.Name.Equals(drinkName, StringComparison.CurrentCultureIgnoreCase));
        }

        private static string GetCurrentDateTimeString()
        {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
