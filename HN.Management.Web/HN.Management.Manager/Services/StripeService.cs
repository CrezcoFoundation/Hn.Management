using HN.Management.Engine.Models.Stripe;
using HN.Management.Manager.Services.Interfaces;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class StripeService : IStripeService
    {
        private readonly CustomerService _customerService;
        private readonly PriceService _priceService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly InvoiceService _invoiceService;
        private readonly SubscriptionService _subscriptionService;
        private readonly SetupIntentService _setupIntentService;

        public StripeService(CustomerService customerService,
                            PriceService priceService,
                            PaymentIntentService paymentIntentService,
                            InvoiceService invoiceService,
                            SubscriptionService subscriptionService,
                            SetupIntentService setupIntentService)
        {
            _customerService = customerService;
            _priceService = priceService;
            _paymentIntentService = paymentIntentService;
            _invoiceService = invoiceService;
            _subscriptionService = subscriptionService;
            _setupIntentService = setupIntentService;
        }

        public async Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken)
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = resource.Email,
                Name = resource.Name,
            };

            var customer = await _customerService.CreateAsync(customerOptions, null, cancellationToken);

            return new CustomerResource(customer.Id, customer.Email, customer.Name);
        }

        public async Task<Customer> GetCustomer(string id, CustomerGetOptions resource, CancellationToken cancellationToken)
        {
            return await _customerService.GetAsync(id, resource, null, cancellationToken);
        }

        public async Task<CustomerResource> UpdateCustomer(string id, CustomerUpdateOptions resource, CancellationToken cancellationToken)
        {
            var customer = await _customerService.UpdateAsync(id, resource, null, cancellationToken);

            return new CustomerResource(customer.Id, customer.Email, customer.Name);
        }

        public async Task<Price> CreatePrice(PriceCreateOptions resource, CancellationToken cancellationToken)
        {
            return await _priceService.CreateAsync(resource, null, cancellationToken);
        }

        public async Task<Price> GetPrice(string id, PriceGetOptions getOptions, CancellationToken cancellationToken)
        {
            return await _priceService.GetAsync(id, getOptions, null, cancellationToken);
        }

        public async Task<Price> UpdatePrice(string id, PriceUpdateOptions updateOptions, CancellationToken cancellationToken)
        {
            return await _priceService.UpdateAsync(id, updateOptions, null, cancellationToken);
        }

        public async Task<SetupIntent> CreateSetupIntent(SetupIntentCreateOptions resource, CancellationToken cancellationToken)
        {
            return await _setupIntentService.CreateAsync(resource, null, cancellationToken);
        }

        public async Task<SetupIntent> GetSetupIntent(string id, SetupIntentGetOptions getOptions, CancellationToken cancellationToken)
        {
            return await _setupIntentService.GetAsync(id, getOptions, null, cancellationToken);
        }

        public async Task<SetupIntent> UpdateSetupIntent(string id, SetupIntentUpdateOptions setupIntentOptions, CancellationToken cancellationToken)
        {
            return await _setupIntentService.UpdateAsync(id, setupIntentOptions, null, cancellationToken);
        }

        public async Task<PaymentIntentResponse> CreatePaymentIntent(PaymentIntentCreateOptions resource, CancellationToken cancellationToken)
        {
            var paymentIntent = await _paymentIntentService.CreateAsync(resource, null, cancellationToken);

            return new PaymentIntentResponse(
                paymentIntent.ClientSecret,
                paymentIntent.Amount,
                paymentIntent.AmountReceived,
                paymentIntent.Currency);
        }

        public async Task<PaymentIntent> GetPaymentIntent(string id, PaymentIntentGetOptions getOptions, CancellationToken cancellationToken)
        {
            return await _paymentIntentService.GetAsync(id, getOptions, null, cancellationToken);
        }

        public async Task<PaymentIntent> UpdatePaymentIntent(string id, PaymentIntentUpdateOptions updateOptions, CancellationToken cancellationToken)
        {
            return await _paymentIntentService.UpdateAsync(id, updateOptions, null, cancellationToken);
        }

        public async Task<Invoice> CreateInvoice(InvoiceCreateOptions resource, CancellationToken cancellationToken)
        {
            return await _invoiceService.CreateAsync(resource, null, cancellationToken);
        }

        public async Task<Invoice> GetInvoice(string id, InvoiceGetOptions getOptions, CancellationToken cancellationToken)
        {
            return await _invoiceService.GetAsync(id, getOptions, null, cancellationToken);
        }

        public async Task<Invoice> UpdateInvoice(string id, InvoiceUpdateOptions updateOptions, CancellationToken cancellationToken)
        {
            return await _invoiceService.UpdateAsync(id, updateOptions, null, cancellationToken);
        }

        public async Task<Subscription> CreateSubscription(SubscriptionCreateOptions resource, CancellationToken cancellationToken)
        {
            return await _subscriptionService.CreateAsync(resource, null, cancellationToken);
        }

        public async Task<Subscription> GetSubscription(string id, SubscriptionGetOptions getOptions, CancellationToken cancellationToken)
        {
            return await _subscriptionService.GetAsync(id, getOptions, null, cancellationToken);
        }

        public async Task<Subscription> UpdateSubscription(string id, SubscriptionUpdateOptions updateOptions, CancellationToken cancellationToken)
        {
            return await _subscriptionService.UpdateAsync(id, updateOptions, null, cancellationToken);
        }
    }
}
