namespace HN.Management.Engine.Models.Paypal
{
    public class PurchaseUnitRequest
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public string Description { get; set; }
        public string CustomId { get; set; }
        public int SoftDescriptor { get; set; }
    }

    public class AmountWithBreakdown
    {
        public int Id { get; set; }
    }
}
