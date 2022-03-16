using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_studies.Core.Services;

public class AuthService : IAuthService
{
    private IConfiguration Configuration { get; }
    
    public AuthService(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public string GenerateToken(Admin admin)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, admin.Email),
                new Claim(ClaimTypes.Role, "ADMIN")
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string Encode(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string passwordHashed, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
    }
}