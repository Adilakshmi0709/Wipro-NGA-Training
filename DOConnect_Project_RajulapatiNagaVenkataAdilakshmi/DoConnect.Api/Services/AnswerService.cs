using DoConnect.Api.Data;
using DoConnect.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Api.Services
{
    public class AnswerService
    {
        private readonly DoConnectDbContext _db;

        public AnswerService(DoConnectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Answer> QueryMyAnswers(int userId)
        {
            return _db.Answers
                .Include(a => a.Question)
                .Include(a => a.Images)
                .Where(a => a.UserId == userId);
        }
        public async Task<Answer?> CreateAsync(int userId, int questionId, string text, IFormFile? image, IWebHostEnvironment env)
        {
            var qExists = await _db.Questions.AnyAsync(q => q.QuestionId == questionId);
            if (!qExists) return null;

            var a = new Answer
            {
                UserId = userId,
                QuestionId = questionId,
                AnswerText = text,
                Status = "Pending"
            };
            _db.Answers.Add(a);
            await _db.SaveChangesAsync();

            if (image != null && image.Length > 0)
            {
                var path = await SaveImageAsync(image, "answers", env);
                _db.Images.Add(new Image { AnswerId = a.AnswerId, ImagePath = path });
                await _db.SaveChangesAsync();
            }

            return a;
        }

        public async Task<List<Answer>> GetMyAnswersAsync(int userId) =>
            await _db.Answers
                .Include(a => a.Question)
                .Include(a => a.Images)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.AnswerId)
                .ToListAsync();

        private static async Task<string> SaveImageAsync(IFormFile file, string folder, IWebHostEnvironment env)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
            Directory.CreateDirectory(root);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(root, fileName);
            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/uploads/{folder}/{fileName}";
        }
    }
}
