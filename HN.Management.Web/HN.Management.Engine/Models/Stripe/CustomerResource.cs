namespace HN.Management.Engine.Models.Stripe
{
    public record CustomerResource(
     string CustomerId,
     string Email,
     string Name);
}
