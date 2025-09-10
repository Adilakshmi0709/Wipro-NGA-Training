using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("🎯 JWT Token Manager");
        Console.WriteLine("====================");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Generate new token (2 minutes)");
        Console.WriteLine("2. Test token expiry (1 minute)");
        Console.WriteLine("3. Check existing token");
        Console.Write("Enter choice (1-3): ");

        var choice = Console.ReadLine();

        string secretKey = "YourSuperLongSecretKey123!ThisShouldBeAtLeast16Chars";
        string issuer = "MyApp";
        string audience = "MyAppUsers";
        string userId = "9881314481";
        string username = "Rushikesh.Magdum";

        switch (choice)
        {
            case "1":
                string token = JwtGenerator.GenerateToken(secretKey, issuer, audience, userId, username, 2);
                JwtGenerator.DisplayTokenInfo(token);
                break;

            case "2":
                TokenExpiryTest.TestTokenExpiry();
                break;

            case "3":
                Console.Write("Paste your token: ");
                string existingToken = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(existingToken))
                {
                    // Use only CheckToken method which definitely exists
                    JwtChecker.CheckToken(existingToken, secretKey, issuer, audience);
                }
                else
                {
                    Console.WriteLine("❌ No token provided!");
                }
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
