using Checkout.ApiServices.ShoppingList;

namespace Checkout
{
    public partial class APIClient
    {
        private ShoppingListService _shoppingListService;

        public ShoppingListService ShoppingListService { get { return _shoppingListService ?? (_shoppingListService = new ShoppingListService()); } }
    }
}
