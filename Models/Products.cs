using System.ComponentModel.DataAnnotations.Schema;

namespace web_cake.Models
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Category { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? Description { get; set; }
    }
}
