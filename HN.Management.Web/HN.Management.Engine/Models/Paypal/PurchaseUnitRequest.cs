using System.Collections.Generic;

namespace HN.Management.Engine.Models.Paypal
{
    public class PurchaseUnitRequest
    {
        public int Id { get; set; }

        public string ReferenceId { get; set; }

        public string Description { get; set; }

        public string CustomId { get; set; }

        public string SoftDescriptor { get; set; }

        public AmountWithBreakdown AmountWithBreakdown { get; set; }

        public List<Item> Items { get; set; }

        public ShippingDetail ShippingDetail { get; set; }
    }
}
