using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Healthcare.Appointments.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Healthcare.Appointments.Infrastructure.Commons;

public static class TokenGenerator
{
    public static string GetToken(User user, IList<string> roles, IConfiguration configuration)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),

        };

        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = GenerateJwtToken(authClaims, configuration);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private static JwtSecurityToken GenerateJwtToken(List<Claim> authClaims, IConfiguration configuration)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(15),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return token;
    }
}