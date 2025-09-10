
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtChecker
{
    public static void CheckToken(string token, string secretKey, string issuer, string audience)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            // First, try to read the token without validation
            Console.WriteLine("🔓 Decoding token structure...");
            var jwtToken = tokenHandler.ReadJwtToken(token);
            Console.WriteLine($"✅ Token format is valid");
            Console.WriteLine($"📋 Issuer: {jwtToken.Issuer}");
            Console.WriteLine($"📋 Audience: {jwtToken.Audiences?.FirstOrDefault()}");
            Console.WriteLine($"📋 Expires: {jwtToken.ValidTo.ToLocalTime()}");

            // Now validate the token properly
            Console.WriteLine("\n🔐 Validating token...");
            var key = Encoding.UTF8.GetBytes(secretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            
            Console.WriteLine("✅ Token is VALID and authentic!");
            Console.WriteLine("==================================");
            
            // Display all claims
            Console.WriteLine("📋 Token Claims:");
            Console.WriteLine("------------------");
            foreach (var claim in principal.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
        }
        catch (SecurityTokenExpiredException)
        {
            Console.WriteLine("❌ Token has EXPIRED!");
            DecodeTokenWithoutValidation(token);
        }
        catch (SecurityTokenInvalidSignatureException)
        {
            Console.WriteLine("❌ Invalid token signature! Secret key mismatch.");
            DecodeTokenWithoutValidation(token);
        }
        catch (SecurityTokenInvalidIssuerException)
        {
            Console.WriteLine("❌ Invalid issuer! Expected: " + issuer);
            DecodeTokenWithoutValidation(token);
        }
        catch (SecurityTokenInvalidAudienceException)
        {
            Console.WriteLine("❌ Invalid audience! Expected: " + audience);
            DecodeTokenWithoutValidation(token);
        }
        catch (ArgumentException ex) when (ex.Message.Contains("JWT"))
        {
            Console.WriteLine("❌ Invalid JWT token format");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Token validation failed: {ex.Message}");
        }
    }

    private static void DecodeTokenWithoutValidation(string token)
    {
        try
        {
            Console.WriteLine("\n🔍 Token contents (without validation):");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Console.WriteLine("📋 Claims:");
            Console.WriteLine("------------------");
            foreach (var claim in jwtToken.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Could not decode token: {ex.Message}");
        }
    }

    // ADD THIS MISSING METHOD:
    public static void QuickCheck(string token)
    {
        try
        {
            Console.WriteLine("🔍 Quick Token Check");
            Console.WriteLine("====================");
            
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Console.WriteLine($"✅ Token format: Valid");
            Console.WriteLine($"📋 Issuer: {jwtToken.Issuer}");
            Console.WriteLine($"📋 Audience: {jwtToken.Audiences?.FirstOrDefault()}");
            Console.WriteLine($"📋 Expires: {jwtToken.ValidTo.ToLocalTime()}");
            
            // Check if expired
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                Console.WriteLine("❌ Status: EXPIRED");
            }
            else
            {
                Console.WriteLine("✅ Status: Not expired");
            }

            Console.WriteLine("\n📋 Claims:");
            Console.WriteLine("------------------");
            foreach (var claim in jwtToken.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Invalid token: {ex.Message}");
        }
    }
}
