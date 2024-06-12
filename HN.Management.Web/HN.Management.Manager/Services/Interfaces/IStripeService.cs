using System.Threading.Tasks;
using System.Threading;
using HN.Management.Engine.Models.Stripe;
using Stripe;
namespace HN.Management.Manager.Services.Interfaces
{
    public interface IStripeService
    {
        Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken);
        Task<CustomerResource> UpdateCustomer(string id, CustomerUpdateOptions resource, CancellationToken cancellationToken);
        Task<Price> CreatePrice(PriceCreateOptions resource, CancellationToken cancellationToken);
        Task<PaymentIntentResponse> CreatePaymentIntent(PaymentIntentCreateOptions resource, CancellationToken cancellationToken);
        Task<Invoice> CreateInvoice(InvoiceCreateOptions resource, CancellationToken cancellationToken);
        Task<Subscription> CreateSubscription(SubscriptionCreateOptions resource, CancellationToken cancellationToken);
        Task<SetupIntent> CreateSetupIntent(SetupIntentCreateOptions resource, CancellationToken cancellationToken);
    }
}
