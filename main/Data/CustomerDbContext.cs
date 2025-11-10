using main.Models;
using Microsoft.EntityFrameworkCore;

namespace main.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
    }
}