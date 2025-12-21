using BookMyShow.Models;

namespace BookMyShow.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
