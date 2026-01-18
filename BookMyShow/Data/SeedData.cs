using BookMyShow.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Users.Any(u => u.Email == "admin@bookmyshow.com"))
            {
                var admin = new User
                {
                    Name = "Admin",
                    Email = "admin@bookmyshow.com",
                    Role = "Admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123")
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
