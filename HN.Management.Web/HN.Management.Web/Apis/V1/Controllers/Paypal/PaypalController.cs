using HN.Management.Engine.Models.Paypal;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers.Paypal
{
    public class PaypalController : Controller
    {
        private readonly IPaypalService paypalService;

        public PaypalController(IPaypalService paypalService)
        {
            this.paypalService = paypalService;
        }

        
        public async Task<IActionResult> CreateOrder(PaypalOrder paypalOrder)
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

                return Ok(await paypalService.CreateOrder(paypalOrder));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
