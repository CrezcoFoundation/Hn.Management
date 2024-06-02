using System;
using System.Collections.Generic;

namespace HN.Management.Engine.Models.Stripe
{
    public record PriceResource(
        string Id,
        string Object,
        bool Active,
        DateTime Created,
        string Currency,
        Dictionary<string, string> Metadata);
}
