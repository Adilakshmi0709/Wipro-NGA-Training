using Xunit;
using Moq;
using DoConnect.Api.Services;
using DoConnect.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Tests.Unit
{
    public class AnswerServiceTests
    {
        private readonly AnswerService _service;
        private readonly DoConnectDbContext _context;

        public AnswerServiceTests()
        {
            var options = new DbContextOptionsBuilder<DoConnectDbContext>()
                .UseInMemoryDatabase("AnswerServiceTestsDb")
                .Options;

            _context = new DoConnectDbContext(options);
            _service = new AnswerService(_context); // ✅ matches your constructor
        }

        [Fact]
        public void AnswerService_CanBeCreated()
        {
            Assert.NotNull(_service);
        }
    }
}
