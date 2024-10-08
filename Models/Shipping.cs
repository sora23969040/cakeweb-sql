namespace web_cake.Models
{
    public class Shipping
    {
        public int OrderId { get; set; }

        public string? ShippingMethod { get; set; }

        public string? TrackingNumber { get; set; }

        public decimal ShippingCost { get; set; }

        public string? ShippingStatus { get; set; }

    }
}
