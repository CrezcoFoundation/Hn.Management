using HN.Management.Engine.Models.Paypal;
using HN.Management.Engine.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;
using PurchaseUnitRequest = PayPalCheckoutSdk.Orders.PurchaseUnitRequest;
using AmountWithBreakdown = PayPalCheckoutSdk.Orders.AmountWithBreakdown;

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

        public async Task<string> GetOrderByIdAsync(string orderId)
        {
            orderId = "0EU46785VX070324S";
            var orderRequest = new OrdersGetRequest(orderId);
            orderRequest.Headers.Add("prefer", "return=representation");
            var paypalClient = new PayPalClient(configuration).GetClient();
            var order = await paypalClient.Execute(orderRequest);

            return order.ToString();
        }

        public async Task<string> ConfirmOrderAsync(string orderId)
        {
            orderId = "7F525878KH724892H";
            var orderRequest = new OrdersCaptureRequest(orderId);
            orderRequest.Headers.Add("prefer", "return=representation");
            orderRequest.RequestBody(new OrderActionRequest());

            var paypalClient = new PayPalClient(configuration).GetClient();
            var order = await paypalClient.Execute(orderRequest);

            return order.ToString();
        }

        public async Task<string> AuthorizeOrderByIdAsync(string orderId)
        {
            orderId = "7F525878KH724892H";
            var orderRequest = new OrdersAuthorizeRequest(orderId);
            orderRequest.Headers.Add("prefer", "return=representation");
            orderRequest.RequestBody(new AuthorizeRequest());

            var paypalClient = new PayPalClient(configuration).GetClient();
            var order = await paypalClient.Execute(orderRequest);

            return order.ToString();
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
                    UserAction = "CONTINUE",
                    ShippingPreference = paypalOrder.ShippingPreference
                },
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        ReferenceId =  "PUHFTEST",
                        Description = "Crezco Foundation Test",
                        CustomId = "DonatationId",
                        SoftDescriptor = "Honduras Program",

                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = paypalOrder.CurrencyCode,
                            Value = "165",
                             AmountBreakdown = new AmountBreakdown
                            {
                                ItemTotal = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "150.00"
                                },

                                TaxTotal = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "15.00"
                                }
                            }
                        },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                Name = "University Plan",
                                Description = "University Program Peru, Honduras, Mexico",
                                Sku = "sku01",
                                UnitAmount = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "100.00"
                                },
                                Tax = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "10.00"
                                },
                                Quantity = "1",
                                Category = "PHYSICAL_GOODS"
                            },
                            new Item
                            {
                                Name = "Hogar Honduras Reach",
                                Description = "Hogar de niños Reach Internacional",
                                Sku = "sku02",
                                UnitAmount = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "50.00"
                                },
                                Tax = new Money
                                {
                                    CurrencyCode = "USD",
                                    Value = "5.00"
                                },
                                Quantity = "1",
                                Category = "PHYSICAL_GOODS"
                            }
                        },
                        ShippingDetail = new ShippingDetail
                        {
                            Name = new Name
                            {
                                FullName = "Amanda Corea"
                            },
                           AddressPortable = new AddressPortable
                           {
                               AddressLine1 = "Hagerstown, Maryland",
                               AddressLine2 = "Rio atengo 2057",
                               AdminArea2 = "test admin area 2",
                               CountryCode = "US",
                               PostalCode = "21740"
                           }
                        }
                    }
                }
            };

            return orderRequest;
        }
    }
}
