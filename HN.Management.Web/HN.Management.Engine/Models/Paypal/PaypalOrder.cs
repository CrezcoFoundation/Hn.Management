using System.Collections.Generic;

namespace HN.Management.Engine.Models.Paypal
{
    public class PaypalOrder
    {
        public string BrandName { get; set; }

        public string LandingPage { get; set; }

        public string UserAction { get; set; }

        public string ShippingPreference { get; set; }

        public string CurrencyCode { get; set; }

        public string AmountValue { get; set; }

        public PurchaseUnitRequest PurchaseUnitRequest { get; set; }
    }
}
