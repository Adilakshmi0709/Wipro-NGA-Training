using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtGenerator
{
    public static string GenerateToken(string secretKey, string issuer, string audience, string userId, string username, int expireMinutes = 60)
    {
        // Ensure secret key is long enough
        if (secretKey.Length < 16)
        {
            throw new ArgumentException("Secret key must be at least 16 characters long");
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "User"),
            new Claim("userId", userId)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static void DisplayTokenInfo(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Console.WriteLine("🔐 JWT Token Created Successfully!");
            Console.WriteLine("==================================");
            Console.WriteLine($"Token: {token}");
            Console.WriteLine("==================================");
            Console.WriteLine("Token Details:");
            Console.WriteLine($"Issuer: {jwtToken.Issuer}");
            Console.WriteLine($"Audience: {jwtToken.Audiences?.FirstOrDefault()}");
            Console.WriteLine($"Expires: {jwtToken.ValidTo.ToLocalTime()}");
            Console.WriteLine($"Subject: {jwtToken.Subject}");
            
            var usernameClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name");
            if (usernameClaim != null)
            {
                Console.WriteLine($"Username: {usernameClaim.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error displaying token info: {ex.Message}");
        }
    }
}