using Microsoft.EntityFrameworkCore;
using main.Data.Entities;

namespace main.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // These properties map to your database tables
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints here

            // Make Username and Email unique in the Users table
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configure the User -> Orders relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Cascade); // If a User is deleted, delete their orders

            // Configure the User -> Feedbacks relationship (the author)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Feedbacks)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Cascade); // If a User is deleted, delete their feedback

            // Configure the Admin -> Feedbacks relationship (the reply)
            // This prevents a cascade delete if an admin is deleted
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.RepliedByUser)
                .WithMany() // No inverse navigation property needed on User for this
                .HasForeignKey(f => f.RepliedByUserID)
                .OnDelete(DeleteBehavior.SetNull); // If Admin is deleted, set RepliedByUserID to null

            // Configure the Order -> OrderItems relationship
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade); // If an Order is deleted, delete its items

            // Configure the Product -> OrderItems relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductID)
                .OnDelete(DeleteBehavior.Restrict); // Don't delete a Product if it's in an order

                        // 1. Seed Products
                modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        ProductID = 1,
                        Name = "Slim Gallon - Refill",
                        Type = "Refill",
                        Price = 25.00m,
                        IsAvailable = true
                    },
                    new Product
                    {
                        ProductID = 2,
                        Name = "Round Gallon - Refill",
                        Type = "Refill",
                        Price = 30.00m,
                        IsAvailable = true
                    },
                    new Product
                    {
                        ProductID = 3,
                        Name = "Slim Gallon - Purchase New",
                        Type = "Purchase",
                        Price = 200.00m,
                        IsAvailable = true
                    },
                    new Product
                    {
                        ProductID = 4,
                        Name = "Round Gallon - Purchase New",
                        Type = "Purchase",
                        Price = 250.00m,
                        IsAvailable = true
                    }
                );

        // 2. Seed Admin User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FullName = "Admin User",
                    Username = "admin",
                    Email = "admin@wsoa.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEI/rU6h10NJmN9iVARyMhPDb0dWTzKqRVCbJFXjNqJ2mXmHBSsE2YqLq4WvSfYdDkQ==",
                    ContactNumber = "09123456789",
                    Address = "123 Admin St, Water Station HQ",
                    Role = "Admin",

                    // --- THIS IS THE FIX ---
                    // Replace DateTime.Now with a static value
                    DateCreated = new DateTime(2025, 1, 1) 
                }
            );
        }
    }
}