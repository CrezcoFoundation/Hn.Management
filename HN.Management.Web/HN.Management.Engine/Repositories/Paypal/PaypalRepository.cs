using HN.Management.Engine.Models.Paypal;
using HN.Management.Engine.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Paypal
{
    public class PaypalRepository : IPaypalRepository
    {
        private readonly IConfiguration configuration;

        public PaypalRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Order> CreateOrder(PaypalOrder paypalOrder)
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBody(paypalOrder));
            var paypalClient = new PayPalClient(configuration).GetClient();
            var order = await paypalClient.Execute(request);
            var result = order.Result<Order>();

            return result;
        }

        private OrderRequest BuildRequestBody(PaypalOrder paypalOrder)
        {
            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                ApplicationContext = new ApplicationContext()
                {
                    BrandName = paypalOrder.BrandName,
                    LandingPage = paypalOrder.LandingPage,
                    UserAction = paypalOrder.UserAction,
                    ShippingPreference = paypalOrder.ShippingPreference
                },
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode =paypalOrder.CurrencyCode,
                            Value = paypalOrder.AmountValue
                        }
                    }
                }
            };

            return orderRequest;
        }
    }
}
