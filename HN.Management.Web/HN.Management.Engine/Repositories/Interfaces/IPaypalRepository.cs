using HN.Management.Engine.Models.Paypal;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IPaypalRepository
    {
        Task<Order> CreateOrder(PaypalOrder paypalOrder);
    }
}
