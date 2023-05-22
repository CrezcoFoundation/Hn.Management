using HN.Management.Engine.Models.Paypal;
using HN.Management.Engine.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;
using PurchaseUnitRequest = PayPalCheckoutSdk.Orders.PurchaseUnitRequest;
using AmountWithBreakdown = PayPalCheckoutSdk.Orders.AmountWithBreakdown;
using AmountBreakdown = PayPalCheckoutSdk.Orders.AmountBreakdown;
using Money = PayPalCheckoutSdk.Orders.Money;
using Item = PayPalCheckoutSdk.Orders.Item;
using ShippingDetail = PayPalCheckoutSdk.Orders.ShippingDetail;
using System.Linq;

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
            var purchaseUnitRequest = paypalOrder.PurchaseUnitRequest;
            var amountWithBreakdown = purchaseUnitRequest.AmountWithBreakdown;
            var shippingDetail = purchaseUnitRequest.ShippingDetail;
            var items = new List<Item>();

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
                        ReferenceId =  purchaseUnitRequest.ReferenceId,
                        Description = purchaseUnitRequest.Description,
                        CustomId = purchaseUnitRequest.CustomId,
                        SoftDescriptor = purchaseUnitRequest.SoftDescriptor,

                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = amountWithBreakdown.CurrencyCode,
                            Value = amountWithBreakdown.Value,

                             AmountBreakdown =  new AmountBreakdown
                            {
                                ItemTotal = new Money
                                {
                                    CurrencyCode = amountWithBreakdown.CurrencyCode,
                                    Value = amountWithBreakdown.AmountBreakdown.ItemTotal.Value
                                },

                                TaxTotal = new Money
                                {
                                    CurrencyCode = amountWithBreakdown.CurrencyCode,
                                    Value = amountWithBreakdown.AmountBreakdown.TaxTotal.Value
                                }
                            }
                        },
                        Items = purchaseUnitRequest.Items.Select(item =>  new Item
                        {
                            Name = item.Name,
                            Description = item.Description,
                            Sku = item.Sku,
                            Quantity = item.Quantity,
                            Category = item.Category,
                            UnitAmount = new Money
                            {
                                CurrencyCode = item.UnitAmount.CurrencyCode,
                                Value = item.UnitAmount.Value,
                            },
                            Tax = new Money
                            {
                                CurrencyCode = item.Tax.CurrencyCode,
                                Value = item.Tax.Value,
                            }
                        }).ToList(),
                        ShippingDetail = new ShippingDetail
                        {
                            Name = new Name
                            {
                                FullName = shippingDetail.FullName,
                            },
                           AddressPortable = new AddressPortable
                           {
                               AddressLine1 =shippingDetail.AddressLine1,
                               AddressLine2 = shippingDetail.AddressLine2,
                               AdminArea2 = shippingDetail.AdminArea2,
                               CountryCode = shippingDetail.CountryCode,
                               PostalCode = shippingDetail.PostalCode,
                           }
                        }
                    }
                }
            };

            return orderRequest;
        }
    }
}
