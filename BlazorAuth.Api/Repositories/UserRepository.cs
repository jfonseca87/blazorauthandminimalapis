using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorAuth.Shared.Models;
using BlazorAuth.Shared.Utils;
using Microsoft.IdentityModel.Tokens;

namespace BlazorAuth.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IEnumerable<User> _users;
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _users = new List<User>
    {
        new User(1, "John", "john@gmail.com", true, Roles.User),
        new User(2, "Jane", "jane@gmail.com", true, Roles.WTSAdmin),
        new User(3, "Bob", "bob@gmail.com", true, Roles.User),
        new User(4, "Alice", "alice@gmail.com", true, Roles.User),
        new User(5, "Mike", "mike@gmail.com", true, Roles.User),
        new User(6, "Jorge", "jorge@gmail.com", true, Roles.Admin),
    };
        _configuration = configuration;
    }

    public IEnumerable<User> GetUsers() => _users;

    public LoginResponse Login(Login login)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(login.Email));
        if (user == null)
        {
            return new LoginResponse(false, "");
        }

        var claims = new[]
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.Name}"),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
            new Claim("IssuedOn", DateTime.UtcNow.ToString()),
        };

        _ = int.TryParse(_configuration["Jwt:Time"], out int time);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(time),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginResponse(true, tokenString);
    }
}