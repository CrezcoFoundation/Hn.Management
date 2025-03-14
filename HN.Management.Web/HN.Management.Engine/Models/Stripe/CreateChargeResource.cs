﻿namespace HN.Management.Engine.Models.Stripe
{
    public record CreateChargeResource(
    string Currency,
    long Amount,
    string CustomerId,
    string ReceiptEmail,
    string Description);
}
