using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ShoppingListWebApi.ApiServices.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Checkout.ShoppingListWebApi.Controllers
{
    public class OrderItemsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetOrderItems()
        {
            return Ok(
                new OrderItemsGetReponse()
                {
                    OrderItems = MockData.OrderItems,
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        [HttpPost]
        public IHttpActionResult GetOrderItems(OrderItemsGetRequest orderItemGetRequest)
        {
            IEnumerable<BaseOrderItem> orderItems = MockData.OrderItems;
            
            if(!string.IsNullOrWhiteSpace(orderItemGetRequest.DrinkNameSearch))
            {
                orderItems = orderItems.Where(o => o.Drink.Name.IndexOf(orderItemGetRequest.DrinkNameSearch, StringComparison.CurrentCultureIgnoreCase) > -1);
            }

            if (orderItemGetRequest.SortColumn != null && orderItemGetRequest.SortOrder != null)
            {
                if (orderItemGetRequest.SortOrder == OrderItemSortOrder.Asc)
                {
                    switch (orderItemGetRequest.SortColumn.Value)
                    {
                        case OrderItemSortColumn.DrinkName:
                            orderItems = orderItems.OrderBy(o => o.Drink.Name, StringComparer.CurrentCultureIgnoreCase);
                            break;

                        case OrderItemSortColumn.CreateDateTime:
                            orderItems = orderItems.OrderBy(o => o.CreateDateTime);
                            break;

                        case OrderItemSortColumn.Quantity:
                            orderItems = orderItems.OrderBy(o => o.Quantity);
                            break;
                    }
                }
                else
                {
                    switch (orderItemGetRequest.SortColumn.Value)
                    {
                        case OrderItemSortColumn.DrinkName:
                            orderItems = orderItems.OrderByDescending(o => o.Drink.Name, StringComparer.CurrentCultureIgnoreCase);
                            break;

                        case OrderItemSortColumn.CreateDateTime:
                            orderItems = orderItems.OrderByDescending(o => o.CreateDateTime);
                            break;

                        case OrderItemSortColumn.Quantity:
                            orderItems = orderItems.OrderByDescending(o => o.Quantity);
                            break;
                    }
                }
            }

            if (orderItemGetRequest.PageNumber > 0 && orderItemGetRequest.PageSize > 0)
            {
                orderItems = orderItems.Skip(orderItemGetRequest.PageSize * (orderItemGetRequest.PageNumber - 1)).Take(orderItemGetRequest.PageSize);
            }

            return Ok(
                new OrderItemsGetReponse()
                {
                    OrderItems = orderItems.ToList(),
                    Created = GetCurrentDateTimeString(),
                    Error = null
                }
            );
        }

        private static bool DrinkIsAvailable(BaseDrink drink)
        {
            return MockData.AvailableDrinks.Any(d => d.Name.Equals(drink.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        private static string GetCurrentDateTimeString()
        {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
