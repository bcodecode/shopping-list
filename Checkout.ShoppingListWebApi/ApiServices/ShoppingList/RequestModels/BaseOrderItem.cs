using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class BaseOrderItem
    {
        public int Quantity { get; set; }

        public BaseDrink Drink { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}