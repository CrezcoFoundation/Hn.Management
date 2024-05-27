namespace HN.Management.Engine.Models.Stripe
{
    public record PaymentIntentResponse(
        string ClientSecret,
        long Amount,
        long AmountReceived,
        string Currency
        );
}
