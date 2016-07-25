using System.Configuration;
namespace Checkout
{
    public partial class ApiUrls
    {
        private static string _orderItemUri;
        private static string _orderItemsUri;
        private static string _resetTestDataUri;

        public static string OrderItemUri
            = _orderItemUri ?? (_orderItemUri = ConfigurationManager.AppSettings["ShoppingListBaseUri"] + "/api/orderitem");

        public static string OrderItemsUri
            = _orderItemsUri ?? (_orderItemsUri = ConfigurationManager.AppSettings["ShoppingListBaseUri"] + "/api/orderitems");

        public static string ResetTestDataUri
            = _resetTestDataUri ?? (_resetTestDataUri = ConfigurationManager.AppSettings["ShoppingListBaseUri"] + "/api/resettestdata");
    }
}