using BookMyShow.Data;
using BookMyShow.DTOs;
using BookMyShow.Models;
using BookMyShow.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task BookAsync(BookingDto dto, int userId)
        {
            if (dto.MovieId <= 0)
                throw new ArgumentException("Invalid MovieId");

            if (dto.Tickets <= 0)
                throw new ArgumentException("Tickets must be greater than 0");

            var movie = await _context.Movies.FindAsync(dto.MovieId);
            if (movie == null)
                throw new ArgumentException("Movie not found");

            if (dto.ShowDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Show date cannot be in the past");

            var booking = new Booking
            {
                MovieId = dto.MovieId,
                UserId = userId,
                ShowDate = dto.ShowDate,
                Tickets = dto.Tickets
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetMyBookingsAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Movie)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }
    }
}
