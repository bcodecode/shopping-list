
using Checkout.ApiServices.SharedModels;
namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class OrderItemsGetRequest
    {
        public string Created { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public string DrinkNameSearch { get; set; }

        public OrderItemSortColumn? SortColumn { get; set; }

        public OrderItemSortOrder? SortOrder { get; set; }
//PageNumber
//         FromDate = fromDate,
//                ToDate = toDate,
//                PageSize = pageSize,
//                PageNumber = pageNumber,
//                SortColumn = sortColumn,
//                SortOrder = sortOrder,
//                Search = searchValue,
//                Filters = filters
    }
}
