using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace main.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // "Refill" or "Purchase"

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation property: A Product can be part of many OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}