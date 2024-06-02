namespace HN.Management.Engine.Models.Stripe
{
    public record CreatePriceResource(
        string Currency,
        int UnitAmount,
        object Recurring,
        object ProductData);
}
