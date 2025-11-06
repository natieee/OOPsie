using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace main.Data.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int UserID { get; set; } // Foreign Key to User

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; } = "Pending";

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; } = "Pending";

        [Required]
        [MaxLength(250)]
        public string DeliveryAddress { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; } = null!; // An Order belongs to one User
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // An Order has many OrderItems
    }
}