using BookMyShow.DTOs;

namespace BookMyShow.Services.Interfaces
{
    public interface IAuthService
    {
        void Register(RegisterDto dto);
        string Login(LoginDto dto);
    }
}
