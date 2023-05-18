using HN.Management.Engine.Models.Paypal;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Paypal
{
    public class PaypalService : IPaypalService
    {
        private readonly IPaypalRepository paypalRepository;
        public PaypalService(IPaypalRepository paypalRepository)
        {
            this.paypalRepository = paypalRepository;
        }

        public async Task<Order> CreateOrder(PaypalOrder paypalOrder)
        {
            return await paypalRepository.CreateOrder(paypalOrder);
        }

        public async Task<string> GetOrderByIdAsync(string orderId)
        {
            return await paypalRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<string> ConfirmOrderByIdAsync(string orderId)
        {
            return await paypalRepository.ConfirmOrderAsync(orderId);
        }

        public async Task<string> AutorizeOrderByIdAsync(string orderId)
        {
            return await paypalRepository.AuthorizeOrderByIdAsync(orderId);
        }
    }
}
