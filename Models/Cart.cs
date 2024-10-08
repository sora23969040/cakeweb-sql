namespace web_cake.Models
{
    public class Cart
    {

        public int ProductId        { get; set; }

        public string? ProductName  { get; set; } = "";

        public decimal Price        { get; set; }

        public int quantity         { get; set; }

    }
}
