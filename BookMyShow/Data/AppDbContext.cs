using BookMyShow.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<User> Users { get; set; }
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Booking> Bookings { get; set; }
    }
}
