using HN.Management.Engine.Models.Paypal;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers.Paypal
{
    [Route("api/[Controller]")]
    public class PaypalController : Controller
    {

        private readonly IPaypalService paypalService;

        public PaypalController(IPaypalService paypalService)
        {
            this.paypalService = paypalService;
        }

        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] PaypalOrder paypalOrder)
        {
            try
            {
                if (paypalOrder == null)
                    throw new ArgumentNullException(nameof(paypalOrder));

                if (string.IsNullOrEmpty(paypalOrder.CurrencyCode))
                    throw new ArgumentNullException(nameof(paypalOrder.CurrencyCode));

                if (string.IsNullOrEmpty(paypalOrder.AmountValue))
                    throw new ArgumentNullException(nameof(paypalOrder.AmountValue));

                if (string.IsNullOrEmpty(paypalOrder.UserAction))
                    throw new ArgumentNullException(nameof(paypalOrder.UserAction));

                if (string.IsNullOrEmpty(paypalOrder.ShippingPreference))
                    throw new ArgumentNullException(nameof(paypalOrder.ShippingPreference));

                paypalOrder = new PaypalOrder()
                {
                    AmountValue = "100",
                    BrandName = "CREZCO Foundation INC Test",
                    ShippingPreference = "SET_PROVIDED_ADDRESS",
                    CurrencyCode = "USD",
                    LandingPage = "BILLING",
                    UserAction = "PAY_NOW"
                };

                var order = await paypalService.CreateOrder(paypalOrder);

                return Ok(new JsonResult(order));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("order")]
        public async Task<string> GetOrderByIdAsync(string orderId)
        {
            try
            {
                return await paypalService.GetOrderByIdAsync(orderId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("authorize-order")]
        public async Task<string> AuthorizeOrderIdAsync(string orderId)
        {
            try
            {
                return await paypalService.AutorizeOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("confirm-order")]
        public async Task<string> ConfirmOrderIdAsync(string orderId)
        {
            try
            {
                return await paypalService.ConfirmOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
