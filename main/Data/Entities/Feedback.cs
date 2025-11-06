using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace main.Data.Entities
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required]
        public int UserID { get; set; } // Foreign Key to User (the author)

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        public bool IsAnonymous { get; set; }

        // Admin reply fields
        public string? AdminReply { get; set; }
        public DateTime? DateReplied { get; set; }
        public int? RepliedByUserID { get; set; } // Nullable Foreign Key to User (the admin)

        // Navigation properties
        public User User { get; set; } = null!; // The author
        
        [ForeignKey("RepliedByUserID")]
        public User? RepliedByUser { get; set; } // The admin who replied
    }
}