using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;

namespace HN.Management.Engine.Repositories.Paypal
{

    public class PayPalClient
    {
        private readonly PayPalHttpClient _client;

        public PayPalClient(IConfiguration config)
        {
            var environment = new SandboxEnvironment(config["PayPal:ClientId"], config["PayPal:ClientSecret"]);
            _client = new PayPalHttpClient(environment);
        }

        public PayPalHttpClient GetClient()
        {
            return _client;
        }
    }
}
