﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Checkout.ApiServices.SharedModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderItemSortOrder
    {
        Asc,
        Desc
    }
}
