namespace HN.Management.Engine.Models.Paypal
{
    public class Item
    {
        public string Category { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Sku { get; set; }

        public Money Tax { get; set; }

        public Money UnitAmount { get; set; }
    }
}
