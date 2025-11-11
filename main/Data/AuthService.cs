// In Data/AuthService.cs
using main.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace main.Data
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(User newUser, string password)
        {
            try
            {
                // Check if username or email already exists
                if (await _context.Users.AnyAsync(u => u.Username == newUser.Username || u.Email == newUser.Email))
                {
                    return false; // Username or Email already taken
                }

                // Hash the password
                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, password);
                
                // Set default role if not provided
                newUser.Role = "Customer";
                newUser.DateCreated = DateTime.Now;

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                return user; // Login successful
            }

            return null; // Invalid password
        }
    }
}