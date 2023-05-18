using HN.Management.Engine.Models.Paypal;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IPaypalRepository
    {
        Task<Order> CreateOrder(PaypalOrder paypalOrder);
        Task<string> GetOrderByIdAsync(string orderId);
        Task<string> ConfirmOrderAsync(string orderId);
        Task<string> AuthorizeOrderByIdAsync(string orderId);
    }

}
