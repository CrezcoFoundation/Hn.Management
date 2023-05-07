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
    }
}
