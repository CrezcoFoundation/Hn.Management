using HN.Management.Engine.Models.Paypal;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IPaypalService
    {
        Task<Order> CreateOrder(PaypalOrder paypalOrder);
        Task<string> GetOrderByIdAsync(string orderId);
        Task<string> ConfirmOrderByIdAsync(string orderId);
        Task<string> AutorizeOrderByIdAsync(string orderId);
    }
}
