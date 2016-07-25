using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ShoppingListWebApi.ApiServices.ShoppingList;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Tests
{
    [TestClass]
    public class CustomersApiTests : BaseServiceTests
    {
        [TestMethod]
        public void TestCustomersApi()
        {
            ResetTestData();
            CreateOrderItem();
            UpdateOrderItem();
            RemoveOrderItem();
            GetOrderItem();
            GetOrderItems();
        }

        public void ResetTestData()
        {
            var result = CheckoutClient.ShoppingListService.ResetTestData();
        }

        public void CreateOrderItem()
        {
            var orderItemNotAvailableDrinkRequest = new OrderItemCreateRequest()
            {
                Drink = MockData.NotAvailableDrink,
                Quantity = 1
            };

            var responseCreateOrderNotAvailableDrink = CheckoutClient.ShoppingListService.CreateOrderItem(orderItemNotAvailableDrinkRequest);

            responseCreateOrderNotAvailableDrink.Should().NotBeNull();
            responseCreateOrderNotAvailableDrink.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseCreateOrderNotAvailableDrink.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseCreateOrderNotAvailableDrink.Model.Error.Should().NotBeNull();
            responseCreateOrderNotAvailableDrink.Model.Error.ShouldBeEquivalentTo(Errors.NotAvailableDrink);
            responseCreateOrderNotAvailableDrink.Model.Drink.ShouldBeEquivalentTo(orderItemNotAvailableDrinkRequest.Drink);
            responseCreateOrderNotAvailableDrink.Model.Quantity.ShouldBeEquivalentTo(0);

            var orderItemCreateRequest = new OrderItemCreateRequest()
            {
                Drink = MockData.Coffee,
                Quantity = 3
            };

            var responseCreateOrder = CheckoutClient.ShoppingListService.CreateOrderItem(orderItemCreateRequest);

            responseCreateOrder.Should().NotBeNull();
            responseCreateOrder.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseCreateOrder.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseCreateOrder.Model.Error.Should().BeNull();
            orderItemCreateRequest.Drink.ShouldBeEquivalentTo(responseCreateOrder.Model.Drink);
            orderItemCreateRequest.Quantity.ShouldBeEquivalentTo(responseCreateOrder.Model.Quantity);

            var responseSecondAttemptCreateOrder = CheckoutClient.ShoppingListService.CreateOrderItem(orderItemCreateRequest);

            responseSecondAttemptCreateOrder.Should().NotBeNull();
            responseSecondAttemptCreateOrder.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseSecondAttemptCreateOrder.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseSecondAttemptCreateOrder.Model.Error.Should().NotBeNull();
            responseSecondAttemptCreateOrder.Model.Error.ShouldBeEquivalentTo(Errors.DrinkAlreadyOrdered);
            orderItemCreateRequest.Drink.ShouldBeEquivalentTo(responseSecondAttemptCreateOrder.Model.Drink);
            responseSecondAttemptCreateOrder.Model.Quantity.ShouldBeEquivalentTo(0);
        }

        public void UpdateOrderItem()
        {
            var orderItemNotAvailableDrinkRequest = new OrderItemUpdateRequest()
            {
                Drink = MockData.NotAvailableDrink,
                Quantity = 4
            };

            var responseUpdateOrderNotAvailableDrink = CheckoutClient.ShoppingListService.UpdateOrderItem(orderItemNotAvailableDrinkRequest);

            responseUpdateOrderNotAvailableDrink.Should().NotBeNull();
            responseUpdateOrderNotAvailableDrink.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseUpdateOrderNotAvailableDrink.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseUpdateOrderNotAvailableDrink.Model.Error.Should().NotBeNull();
            responseUpdateOrderNotAvailableDrink.Model.Error.ShouldBeEquivalentTo(Errors.NotAvailableDrink);
            responseUpdateOrderNotAvailableDrink.Model.Drink.ShouldBeEquivalentTo(orderItemNotAvailableDrinkRequest.Drink);
            responseUpdateOrderNotAvailableDrink.Model.Quantity.ShouldBeEquivalentTo(0);

            var orderItemUpdateRequestNotYetOrdered = new OrderItemUpdateRequest()
            {
                Drink = MockData.Sprite,
                Quantity = 1
            };

            var responseUpdateOrderNotYetOrdered = CheckoutClient.ShoppingListService.UpdateOrderItem(orderItemUpdateRequestNotYetOrdered);

            responseUpdateOrderNotYetOrdered.Should().NotBeNull();
            responseUpdateOrderNotYetOrdered.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseUpdateOrderNotYetOrdered.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseUpdateOrderNotYetOrdered.Model.Error.Should().NotBeNull();
            responseUpdateOrderNotYetOrdered.Model.Error.ShouldBeEquivalentTo(Errors.DrinkHasNotBeenOrderedYet);
            orderItemUpdateRequestNotYetOrdered.Drink.ShouldBeEquivalentTo(responseUpdateOrderNotYetOrdered.Model.Drink);
            responseUpdateOrderNotYetOrdered.Model.Quantity.ShouldBeEquivalentTo(0);

            var orderItemUpdateRequest = new OrderItemUpdateRequest()
            {
                Drink = MockData.Pepsi,
                Quantity = 1
            };

            var responseUpdateOrder = CheckoutClient.ShoppingListService.UpdateOrderItem(orderItemUpdateRequest);

            responseUpdateOrder.Should().NotBeNull();
            responseUpdateOrder.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseUpdateOrder.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseUpdateOrder.Model.Error.Should().BeNull();
            orderItemUpdateRequest.Drink.ShouldBeEquivalentTo(responseUpdateOrder.Model.Drink);
            orderItemUpdateRequest.Quantity.ShouldBeEquivalentTo(responseUpdateOrder.Model.Quantity);
        }

        public void RemoveOrderItem()
        {
            var orderItemRemoveRequest = new OrderItemRemoveRequest()
            {
                Name = MockData.Pepsi.Name
            };

            var response = CheckoutClient.ShoppingListService.RemoveOrderItem(orderItemRemoveRequest);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Created.Should().NotBeNullOrWhiteSpace();
            response.Model.Error.Should().BeNull();
            response.Model.Drink.ShouldBeEquivalentTo(orderItemRemoveRequest);
            response.Model.Quantity.ShouldBeEquivalentTo(0);

            var responseSecondAttempt = CheckoutClient.ShoppingListService.RemoveOrderItem(orderItemRemoveRequest);

            responseSecondAttempt.Should().NotBeNull();
            responseSecondAttempt.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            responseSecondAttempt.Model.Created.Should().NotBeNullOrWhiteSpace();
            responseSecondAttempt.Model.Error.Should().NotBeNull();
            responseSecondAttempt.Model.Error.ShouldBeEquivalentTo(Errors.DrinkHasNotBeenOrderedYet);
            responseSecondAttempt.Model.Drink.Should().BeNull();
            responseSecondAttempt.Model.Quantity.ShouldBeEquivalentTo(0);
        }

        public void GetOrderItem()
        {
            var orderItemGetRequest = new OrderItemGetRequest()
            {
                Name = MockData.Fanta.Name
            };

            var response = CheckoutClient.ShoppingListService.GetOrderItem(orderItemGetRequest);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Created.Should().NotBeNullOrWhiteSpace();
            response.Model.Error.Should().BeNull();
            response.Model.Drink.ShouldBeEquivalentTo(orderItemGetRequest);
            response.Model.Quantity.ShouldBeEquivalentTo(1);
        }

        public void GetOrderItems()
        {
            var orderItemsGetRequest = new OrderItemsGetRequest()
            {
                PageSize = 1,
                PageNumber = 2,
                SortColumn = OrderItemSortColumn.DrinkName,
                SortOrder = OrderItemSortOrder.Asc,
                DrinkNameSearch = "e"
            };

            var response = CheckoutClient.ShoppingListService.GetOrderItems(orderItemsGetRequest);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Created.Should().NotBeNullOrWhiteSpace();
            response.Model.Error.Should().BeNull();
            response.Model.OrderItems.Count.ShouldBeEquivalentTo(1);
            response.Model.OrderItems[0].Drink.ShouldBeEquivalentTo(MockData.Coffee);
        }
    }
}