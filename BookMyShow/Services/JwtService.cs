using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookMyShow.Models;
using BookMyShow.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    public JwtService(IConfiguration config) => _config = config;

    public string GenerateToken(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // nameid used by controller
            new Claim(ClaimTypes.Name, user.Email ?? string.Empty),
        };

        if (!string.IsNullOrWhiteSpace(user.Role))
            claims.Add(new Claim(ClaimTypes.Role, user.Role)); // role used by [Authorize(Roles="User")]

        var keyBytes = Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? string.Empty);
        if (keyBytes.Length < 32)
            throw new InvalidOperationException("Jwt:Key must be at least 32 bytes for HS256. Use a longer secret or a Base64 encoded 32+ byte key.");

        var signingKey = new SymmetricSecurityKey(keyBytes);
        var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            notBefore: now,
            expires: now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}