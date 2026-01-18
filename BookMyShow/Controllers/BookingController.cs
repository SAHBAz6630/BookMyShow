using BookMyShow.DTOs;
using BookMyShow.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookMyShow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // 🔹 BOOK NOW
        [HttpPost("book-now")]
        public async Task<IActionResult> BookNow([FromBody] BookingDto dto)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            await _bookingService.BookAsync(dto, userId);

            return Ok(new { message = "🎉 Booking successful" });
        }

        // 🔹 MY BOOKINGS
        [HttpGet("my-bookings")]
        public async Task<IActionResult> MyBookings()
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var bookings = await _bookingService.GetMyBookingsAsync(userId);
            return Ok(bookings);
        }
    }
}
