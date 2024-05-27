using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HN.Management.Engine.Models.Stripe;
using System.Threading;
using HN.Management.Manager.Services.Interfaces;
using Stripe;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController : Controller
    {
        private readonly IStripeService _stripeService;
        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        #region Customers 
        public async Task<ActionResult<CustomerResource>> CreateCustomer([FromBody] CreateCustomerResource resource,
               CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateCustomer(resource, cancellationToken);
            return Ok(response);
        }

        [HttpPut("customer/{id}")]
        public async Task<ActionResult<Invoice>> UpdateCustomer([FromBody] string id, CustomerUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdateCustomer(id, resource, cancellationToken);
            return Ok(response);
        }
        #endregion

        [HttpPost("price")]
        public async Task<ActionResult<PriceResource>> CreatePrice([FromBody] PriceCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreatePrice(resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("paymentIntent")]
        public async Task<ActionResult<PaymentIntentResponse>> CreatePaymentIntent([FromBody] PaymentIntentCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreatePaymentIntent(resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("invoice")]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] InvoiceCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateInvoice(resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("subscription")]
        public async Task<ActionResult<Subscription>> CreateSubscription([FromBody] SubscriptionCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateSubscription(resource, cancellationToken);
            return Ok(response);
        }
    }
}
