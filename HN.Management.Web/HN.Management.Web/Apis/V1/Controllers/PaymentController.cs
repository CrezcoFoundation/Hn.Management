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
        [HttpPost("customer")]
        public async Task<ActionResult<CustomerResource>> CreateCustomer([FromBody] CreateCustomerResource resource,
               CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateCustomer(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<Invoice>> GetCustomer([FromRoute] string id, [FromBody] CustomerGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetCustomer(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("customer/{id}")]
        public async Task<ActionResult<Invoice>> UpdateCustomer([FromRoute] string id, [FromBody] CustomerUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdateCustomer(id, resource, cancellationToken);
            return Ok(response);
        }
        #endregion

        [HttpPost("price")]
        public async Task<ActionResult<Price>> CreatePrice([FromBody] PriceCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreatePrice(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("price/{id}")]
        public async Task<ActionResult<Price>> GetPrice([FromRoute] string id, [FromBody] PriceGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetPrice(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("price/{id}")]
        public async Task<ActionResult<Price>> UpdatePrice([FromRoute] string id, [FromBody] PriceUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdatePrice(id, resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("setupIntent")]
        public async Task<ActionResult<PaymentIntentResponse>> CreateSetupIntent([FromBody] SetupIntentCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateSetupIntent(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("setupIntent/{id}")]
        public async Task<ActionResult<SetupIntent>> GetSetupIntent([FromRoute] string id, [FromBody] SetupIntentGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetSetupIntent(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("setupIntent/{id}")]
        public async Task<ActionResult<SetupIntent>> UpdateSetupIntent([FromRoute] string id, [FromBody] SetupIntentUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdateSetupIntent(id, resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("paymentIntent")]
        public async Task<ActionResult<PaymentIntentResponse>> CreatePaymentIntent([FromBody] PaymentIntentCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreatePaymentIntent(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("paymentIntent/{id}")]
        public async Task<ActionResult<PaymentIntent>> GetPaymentIntent([FromRoute] string id, [FromBody] PaymentIntentGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetPaymentIntent(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("paymentIntent/{id}")]
        public async Task<ActionResult<PaymentIntent>> UpdatePaymentIntent([FromRoute] string id, [FromBody] PaymentIntentUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdatePaymentIntent(id, resource, cancellationToken);
            return Ok(response);
        }

        [HttpPost("invoice")]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] InvoiceCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateInvoice(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("invoice/{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice([FromRoute] string id, [FromBody] InvoiceGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetInvoice(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("invoice/{id}")]
        public async Task<ActionResult<Invoice>> UpdateInvoice([FromRoute] string id, [FromBody] InvoiceUpdateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdateInvoice(id, resource, cancellationToken);
            return Ok(response);
        }


        [HttpPost("subscription")]
        public async Task<ActionResult<Subscription>> CreateSubscription([FromBody] SubscriptionCreateOptions resource, CancellationToken cancellationToken)
        {
            var response = await _stripeService.CreateSubscription(resource, cancellationToken);
            return Ok(response);
        }

        [HttpGet("subscription/{id}")]
        public async Task<ActionResult<Invoice>> GetSubscription([FromRoute] string id, [FromBody] SubscriptionGetOptions getOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.GetSubscription(id, getOptions, cancellationToken);
            return Ok(response);
        }

        [HttpPut("subscription/{id}")]
        public async Task<ActionResult<Invoice>> UpdateSubscription([FromRoute] string id, [FromBody] SubscriptionUpdateOptions updateOptions, CancellationToken cancellationToken)
        {
            var response = await _stripeService.UpdateSubscription(id, updateOptions, cancellationToken);
            return Ok(response);
        }

    }
}
