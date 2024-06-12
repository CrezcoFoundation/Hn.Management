using System.Threading.Tasks;
using System.Threading;
using HN.Management.Engine.Models.Stripe;
using Stripe;
namespace HN.Management.Manager.Services.Interfaces
{
    public interface IStripeService
    {
        Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken);
        Task<Customer> GetCustomer(string id, CustomerGetOptions resource, CancellationToken cancellationToken);
        Task<CustomerResource> UpdateCustomer(string id, CustomerUpdateOptions resource, CancellationToken cancellationToken);
        Task<Price> CreatePrice(PriceCreateOptions resource, CancellationToken cancellationToken);
        Task<PaymentIntentResponse> CreatePaymentIntent(PaymentIntentCreateOptions resource, CancellationToken cancellationToken);
        Task<Invoice> CreateInvoice(InvoiceCreateOptions resource, CancellationToken cancellationToken);
        Task<Subscription> CreateSubscription(SubscriptionCreateOptions resource, CancellationToken cancellationToken);
        Task<SetupIntent> CreateSetupIntent(SetupIntentCreateOptions resource, CancellationToken cancellationToken);
        Task<Price> GetPrice(string id, PriceGetOptions getOptions, CancellationToken cancellationToken);
        Task<Price> UpdatePrice(string id, PriceUpdateOptions resource, CancellationToken cancellationToken);
        Task<SetupIntent> GetSetupIntent(string id, SetupIntentGetOptions getOptions, CancellationToken cancellationToken);
        Task<SetupIntent> UpdateSetupIntent(string id, SetupIntentUpdateOptions resource, CancellationToken cancellationToken);
        Task<PaymentIntent> GetPaymentIntent(string id, PaymentIntentGetOptions getOptions, CancellationToken cancellationToken);
        Task<PaymentIntent> UpdatePaymentIntent(string id, PaymentIntentUpdateOptions resource, CancellationToken cancellationToken);
        Task<Invoice> GetInvoice(string id, InvoiceGetOptions getOptions, CancellationToken cancellationToken);
        Task<Invoice> UpdateInvoice(string id, InvoiceUpdateOptions resource, CancellationToken cancellationToken);
        Task<Subscription> GetSubscription(string id, SubscriptionGetOptions getOptions, CancellationToken cancellationToken);
        Task<Subscription> UpdateSubscription(string id, SubscriptionUpdateOptions updateOptions, CancellationToken cancellationToken);
    }
}
