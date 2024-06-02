namespace HN.Management.Engine.Models.Stripe
{
    public record CreateCustomerResource(
    string Email,
    string Name,
    CreateCardResource Card);
}
