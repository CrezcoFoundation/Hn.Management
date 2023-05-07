using HN.Management.Engine.Models.Paypal;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IPaypalService
    {
        Task<Order> CreateOrder(PaypalOrder paypalOrder);
    }
}
