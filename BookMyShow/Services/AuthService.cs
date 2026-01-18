using BookMyShow.Data;
using BookMyShow.DTOs;
using BookMyShow.Models;
using BookMyShow.Services.Interfaces;


namespace BookMyShow.Services
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthService(AppDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public void Register(RegisterDto dto)
        {
            if (_context.Users.Any(x => x.Email == dto.Email))
                throw new Exception("User already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = string.IsNullOrEmpty(dto.Role) ? "User" : dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public string Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return _jwtService.GenerateToken(user);
        }
    }
}
