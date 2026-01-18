
using BookMyShow.DTOs;
using BookMyShow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookingService
{
    Task BookAsync(BookingDto dto, int userId);
    Task<List<Booking>> GetMyBookingsAsync(int userId);
}