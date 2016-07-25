
namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public static class Errors
    {
        public static Error NotAvailableDrink = new Error() { ErrorCode = 1000, ErrorMessage = "The specified drink is not available." };
        public static Error DrinkAlreadyOrdered = new Error() { ErrorCode = 1001, ErrorMessage = "The drink has already been ordered. Please use PUT request to update order quantity." };
        public static Error DrinkHasNotBeenOrderedYet = new Error() { ErrorCode = 1001, ErrorMessage = "The drink has not been ordered yet. Please use POST request to create an order item for this drink." };
    }
}
