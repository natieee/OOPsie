using main.Models;
using Microsoft.EntityFrameworkCore;

namespace main.Data
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
    }
}
