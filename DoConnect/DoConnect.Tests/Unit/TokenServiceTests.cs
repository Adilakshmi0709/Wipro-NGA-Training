using System;
using DoConnect.Api.Models;
using DoConnect.Api.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DoConnect.Tests.Unit
{
    public class TokenServiceTests
    {
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            // Mock IConfiguration for Jwt settings
            var inMemorySettings = new Dictionary<string, string>
            {
                {"Jwt:Key", "ThisIsASuperSecretKeyForJwtToken12345"},
                {"Jwt:Issuer", "DoConnect"},
                {"Jwt:Audience", "DoConnectUsers"}
            };

            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            _tokenService = new TokenService(config);
        }

        [Fact(DisplayName = "GenerateToken should return a valid JWT for a user")]
        public void GenerateToken_Returns_ValidToken()
        {
            // Arrange
            var user = new User
            {
                UserId = 1,
                Username = "testuser",
                Role = "Admin"
            };

            // Act
            var token = _tokenService.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrEmpty(token)); // token should not be null or empty
            Assert.Contains(".", token); // JWT should have at least 2 dots (3 parts)
        }
    }
}
