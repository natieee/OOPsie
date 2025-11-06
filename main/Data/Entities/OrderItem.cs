using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace main.Data.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        public int OrderID { get; set; } // Foreign Key to Order

        [Required]
        public int ProductID { get; set; } // Foreign Key to Product

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; } // Price at the time of purchase

        // Navigation properties
        public Order Order { get; set; } = null!; // Belongs to one Order
        public Product Product { get; set; } = null!; // Is one Product
    }
}