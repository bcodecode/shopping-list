using Checkout.ApiServices.ShoppingList.RequestModels;
using System;
using System.Collections.Generic;

namespace Checkout.ShoppingListWebApi.ApiServices.ShoppingList
{
    public static class MockData
    {
        public static BaseDrink Coffee = new BaseDrink() { Name = "Coffee" };
        public static BaseDrink Pepsi = new BaseDrink() { Name = "Pepsi" };
        public static BaseDrink Fanta = new BaseDrink() { Name = "Fanta" };
        public static BaseDrink Sprite = new BaseDrink() { Name = "Sprite" };
        public static BaseDrink Beer = new BaseDrink() { Name = "Beer" };
        public static BaseDrink NotAvailableDrink = new BaseDrink() { Name = "NotAvailableDrink" };

        public static List<BaseDrink> AvailableDrinks = new List<BaseDrink>() { Pepsi, Fanta, Sprite, Beer, Coffee };

        public static List<BaseOrderItem> OrderItems = new List<BaseOrderItem>() 
        {
            new BaseOrderItem() { Drink = MockData.Pepsi, Quantity = 3, CreateDateTime = DateTime.Now },
            new BaseOrderItem() { Drink = MockData.Beer, Quantity = 1, CreateDateTime = DateTime.Now.AddMinutes(-10) },
            new BaseOrderItem() { Drink = MockData.Fanta, Quantity = 1, CreateDateTime = DateTime.Now.AddMinutes(-15) }
        };
    }
}