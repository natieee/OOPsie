using main.Models;
using Microsoft.EntityFrameworkCore;

namespace main.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users => Set<User>();
    }
}