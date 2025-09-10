using Xunit;
using Moq;
using DoConnect.Api.Services;
using DoConnect.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace DoConnect.Tests.Unit
{
    public class QuestionServiceTests
    {
        private readonly QuestionService _service;
        private readonly DoConnectDbContext _context;

        public QuestionServiceTests()
        {
            var options = new DbContextOptionsBuilder<DoConnectDbContext>()
                .UseInMemoryDatabase("QuestionServiceTestsDb")
                .Options;

            _context = new DoConnectDbContext(options);

            var mockEnv = new Mock<IWebHostEnvironment>(); // ✅ required by your constructor
            _service = new QuestionService(_context, mockEnv.Object);
        }

        [Fact]
        public void QuestionService_CanBeCreated()
        {
            Assert.NotNull(_service);
        }
    }
}
