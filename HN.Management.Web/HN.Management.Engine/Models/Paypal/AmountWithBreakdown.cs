namespace HN.Management.Engine.Models.Paypal
{
    public class AmountWithBreakdown
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }

        public string Value { get; set; }

        public AmountBreakdown AmountBreakdown { get; set; }
    }
}
