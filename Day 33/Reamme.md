
🔐 JWT Token Manager
A simple console application for generating, validating, and testing JWT (JSON Web Tokens) tokens with expiration tracking.

🚀 Features
Token Generation: Create secure JWT tokens with custom claims

Token Validation: Validate tokens with secret key verification

Expiration Testing: Test token expiration with countdown timers

Quick Checking: Decode tokens without validation for inspection

Custom Claims: Add user ID, username, roles, and custom claims

📦 Project Structure
text
JwtApp/
├── JwtGenerator.cs     # Token creation and display
├── JwtChecker.cs       # Token validation and decoding  
├── TokenExpiryTest.cs  # Expiration testing utilities
├── Program.cs          # Main menu and application logic
└── JwtApp.csproj      # Project configuration
🛠️ Installation & Setup
Prerequisites
.NET 6.0 or later

Visual Studio Code or any IDE

Installation
Create the project:

bash
mkdir JwtApp
cd JwtApp
dotnet new console
Add required packages:

bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
Create the files:

Copy the provided code into respective files

JwtGenerator.cs, JwtChecker.cs, TokenExpiryTest.cs, Program.cs

Run the application:

cd MySecureApp
dotnet clean
dotnet build
dotnet run --urls="http://localhost:5050;https://localhost:7050"



🎯 Usage
Main Menu Options
The application provides a menu with 4 options:

Generate new token (2 minutes)

Creates a JWT token that expires in 2 minutes

Displays token details and encoded string

Test token expiry (1 minute)

Creates a token that expires in 1 minute

Shows real-time countdown and validation results

Check existing token (full validation)

Paste any JWT token for complete validation

Verifies signature, issuer, audience, and expiration

Quick token check (format only)

Decodes token without validation

Shows claims and structure for inspection

Example Workflow
Generate a token (Option 1)

text
Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
Expires: 2024-12-31 2:30:45 PM
Validate the token (Option 3)

text
✅ Token is VALID and authentic!
Claims: sub: 9881314481, unique_name: Rushikesh.Magdum
Test expiration (Option 2)

text
⏳ Waiting for 1 minute...
✅ 1 minute has passed!
❌ Token has EXPIRED!
⚙️ Configuration
Secret Key Requirements
Minimum length: 16 characters for HS256 algorithm

Recommended: 32+ characters for production

Example: "YourSuperLongSecretKey123!ThisShouldBeAtLeast16Chars"

Default Settings
csharp
string secretKey = "YourSuperLongSecretKey123!ThisShouldBeAtLeast16Chars";
string issuer = "MyApp";
string audience = "MyAppUsers"; 
string userId = "9881314481";
string username = "Rushikesh.Magdum";
int expireMinutes = 60;
🔧 Customization
Modify Token Claims
Edit the GenerateToken method in JwtGenerator.cs:

csharp
var claims = new[]
{
    new Claim(JwtRegisteredClaimNames.Sub, userId),
    new Claim(JwtRegisteredClaimNames.UniqueName, username),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    new Claim(ClaimTypes.Role, "User"),
    new Claim("userId", userId),
    new Claim("customClaim", "customValue")  // Add custom claims
};
Change Token Expiration
Modify the expireMinutes parameter:

csharp
// For quick testing (1 minute)
string token = JwtGenerator.GenerateToken(secretKey, issuer, audience, userId, username, 1);

// For longer duration (60 minutes)  
string token = JwtGenerator.GenerateToken(secretKey, issuer, audience, userId, username, 60);
🐛 Troubleshooting
Common Issues
"Secret key is too short" error

Solution: Use a longer secret key (minimum 16 characters)

Token validation fails

Check: Secret key, issuer, and audience must match between generation and validation

"Method not found" errors

Solution: Ensure all files are saved and project is rebuilt

Debug Commands
bash
# Clean and rebuild
dotnet clean
dotnet build

# Run with detailed output
dotnet run --verbosity detailed
🚀 Production Recommendations
Secure Secret Storage

csharp
// Use environment variables or secure configuration
string secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") 
                   ?? throw new Exception("JWT secret not configured");
Proper Key Management

Use RSA keys for better security

Rotate keys regularly

Use different keys for different environments

Validation Parameters

csharp
var validationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = true,
    ValidIssuer = issuer,
    ValidateAudience = true, 
    ValidAudience = audience,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.FromMinutes(5) // Allow 5 minutes clock skew
};
📋 API Reference
JwtGenerator Class
GenerateToken(secretKey, issuer, audience, userId, username, expireMinutes)

DisplayTokenInfo(token)

JwtChecker Class
CheckToken(token, secretKey, issuer, audience) - Full validation

QuickCheck(token) - Decode without validation

TokenExpiryTest Class
TestTokenExpiry() - Comprehensive expiration test

QuickExpiryTest() - Quick expiration check

🔒 Security Notes
This is a demo application for learning purposes

Do not use in production without proper security enhancements

Always store secrets securely (not in code)

Use HTTPS in production environments

Implement proper token revocation mechanisms

📝 License
This project is created for educational purposes. Feel free to modify and use for learning JWT token concepts.

🤝 Contributing
Feel free to extend this application with:

Token revocation lists

Different encryption algorithms

Refresh token functionality

Database storage for tokens

Web API integration

🆘 Support
If you encounter issues:

Check all files are saved (Ctrl+S)

Verify secret key length (minimum 16 characters)

Ensure consistent issuer/audience values

Rebuild the project: dotnet clean && dotnet build

Happy Coding! 🎉