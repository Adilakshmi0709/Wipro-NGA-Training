using Xunit;
using Moq;
using DoConnect.Api.Services;
using DoConnect.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Tests.Unit
{
    public class AuthServiceTests
    {
        private readonly AuthService _service;
        private readonly DoConnectDbContext _context;

        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<DoConnectDbContext>()
                .UseInMemoryDatabase("AuthServiceTestsDb")
                .Options;

            _context = new DoConnectDbContext(options);
            _service = new AuthService(_context); // ✅ matches your constructor
        }

        [Fact]
        public void AuthService_CanBeCreated()
        {
            Assert.NotNull(_service);
        }
    }
}
