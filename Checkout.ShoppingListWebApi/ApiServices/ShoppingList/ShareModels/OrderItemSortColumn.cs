﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Checkout.ApiServices.SharedModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderItemSortColumn
    {
        DrinkName,
        Quantity,
        CreateDateTime
    }
}
