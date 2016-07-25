using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
namespace Checkout.ApiServices.ShoppingList
{
public class ShoppingListService
{
    public HttpResponse<OrderItemCreateReponse> CreateOrderItem(OrderItemCreateRequest requestModel)
    {
        return new ApiHttpClient().PostRequest<OrderItemCreateReponse>(ApiUrls.OrderItemUri, AppSettings.SecretKey, requestModel);
    }

    public HttpResponse<OrderItemUpdateReponse> UpdateOrderItem(OrderItemUpdateRequest requestModel)
    {
        return new ApiHttpClient().PutRequest<OrderItemUpdateReponse>(ApiUrls.OrderItemUri, AppSettings.SecretKey, requestModel);
    }

    public HttpResponse<OrderItemRemoveReponse> RemoveOrderItem(OrderItemRemoveRequest requestModel)
    {
        return new ApiHttpClient().DeleteRequest<OrderItemRemoveReponse>(ApiUrls.OrderItemUri.TrimEnd('/') + '/' + requestModel.Name, AppSettings.SecretKey);
    }

    public HttpResponse<OrderItemGetReponse> GetOrderItem(OrderItemGetRequest requestModel)
    {
        return new ApiHttpClient().GetRequest<OrderItemGetReponse>(ApiUrls.OrderItemUri.TrimEnd('/') + '/' + requestModel.Name, AppSettings.SecretKey);
    }

    public HttpResponse<OrderItemsGetReponse> GetOrderItems()
    {
        return new ApiHttpClient().GetRequest<OrderItemsGetReponse>(ApiUrls.OrderItemsUri, AppSettings.SecretKey);
    }

    public HttpResponse<OrderItemsGetReponse> GetOrderItems(OrderItemsGetRequest requestModel)
    {
        return new ApiHttpClient().PostRequest<OrderItemsGetReponse>(ApiUrls.OrderItemsUri, AppSettings.SecretKey, requestModel);
    }

    public HttpResponse<string> ResetTestData()
    {
        return new ApiHttpClient().GetRequest<string>(ApiUrls.ResetTestDataUri, AppSettings.SecretKey);
    }
}

}