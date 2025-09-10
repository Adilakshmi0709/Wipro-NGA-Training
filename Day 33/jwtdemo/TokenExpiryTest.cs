using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenExpiryTest
{
    public static void TestTokenExpiry()
    {
        Console.WriteLine("⏰ Testing Token Expiry");
        Console.WriteLine("=======================");

        // Generate a token that expires in 1 minute (for quick testing)
        string secretKey = "YourSuperLongSecretKey123!ThisShouldBeAtLeast16Chars";
        string issuer = "MyApp";
        string audience = "MyAppUsers";
        string userId = "12345";
        string username = "john.doe";
        
        // Create token that expires in 1 minute
        string token = JwtGenerator.GenerateToken(secretKey, issuer, audience, userId, username, 1);
        
        Console.WriteLine($"Token created at: {DateTime.Now}");
        Console.WriteLine($"Token will expire at: {DateTime.Now.AddMinutes(1)}");
        Console.WriteLine($"Token: {token}");
        
        // Check token immediately
        Console.WriteLine("\n🔍 Checking token immediately:");
        CheckTokenNow(token, secretKey, issuer, audience);
        
        // Wait for 1 minute
        Console.WriteLine($"\n⏳ Waiting for 1 minute... (until {DateTime.Now.AddMinutes(1)})");
        Console.WriteLine("Don't close the terminal!");
        
        // Countdown timer
        for (int i = 60; i > 0; i--)
        {
            Console.Write($"\rTime remaining: {i} seconds");
            System.Threading.Thread.Sleep(1000); // Wait 1 second
        }
        
        Console.WriteLine("\n\n✅ 1 minute has passed!");
        Console.WriteLine($"Current time: {DateTime.Now}");
        
        // Check token again after waiting
        Console.WriteLine("\n🔍 Checking token after 1 minute:");
        CheckTokenNow(token, secretKey, issuer, audience);
    }
    
    private static void CheckTokenNow(string token, string secretKey, string issuer, string audience)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true, // This checks expiration!
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            Console.WriteLine("✅ Token is still VALID");
        }
        catch (SecurityTokenExpiredException)
        {
            Console.WriteLine("❌ Token has EXPIRED!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}