using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace main.Data.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "Customer"; // Default role

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation properties: A User can have many Orders and many Feedbacks
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}