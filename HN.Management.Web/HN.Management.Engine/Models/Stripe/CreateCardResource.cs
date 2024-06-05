
namespace HN.Management.Engine.Models.Stripe
{
    public record CreateCardResource(
    string Name,
    string Number,
    string ExpiryYear,
    string ExpiryMonth,
    string Cvc);
}
