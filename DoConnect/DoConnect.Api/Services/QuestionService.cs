using DoConnect.Api.Data;
using DoConnect.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Api.Services
{
    public class QuestionService
    {
        private readonly DoConnectDbContext _db;
        private readonly IWebHostEnvironment _env;

        public QuestionService(DoConnectDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IQueryable<Question> QueryMyQuestions(int userId)
        {
            return _db.Questions
                .Include(q => q.Images)
                .Where(q => q.UserId == userId);
        }
        public async Task<Question> CreateAsync(int userId, string title, string text, IFormFile? image)
        {
            var q = new Question
            {
                UserId = userId,
                QuestionTitle = title,
                QuestionText = text,
                Status = "Pending"
            };
            _db.Questions.Add(q);
            await _db.SaveChangesAsync();

            if (image != null && image.Length > 0)
            {
                var path = await SaveImageAsync(image, "questions");
                _db.Images.Add(new Image { QuestionId = q.QuestionId, ImagePath = path });
                await _db.SaveChangesAsync();
            }

            return q;
        }

        public async Task<List<Question>> SearchAsync(string? query, string role, int? requesterId)
        {
            var baseQuery = _db.Questions
                .Include(q => q.Images)
                .Include(q => q.Answers.Where(a => a.Status == "Approved"))
                    .ThenInclude(a => a.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                var qLower = query.ToLower();
                baseQuery = baseQuery.Where(q =>
                    q.QuestionTitle.ToLower().Contains(qLower) ||
                    q.QuestionText.ToLower().Contains(qLower));
            }

            if (role == "Admin")
                return await baseQuery.OrderByDescending(q => q.QuestionId).ToListAsync();

            // User role: only approved OR own
            return await baseQuery
                .Where(q => q.Status == "Approved" || q.UserId == requesterId)
                .OrderByDescending(q => q.QuestionId)
                .ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id, string role, int? requesterId)
        {
            var q = await _db.Questions
                .Include(q => q.Images)
                .Include(q => q.Answers)
                    .ThenInclude(a => a.Images)
                .Include(q => q.User)
                .FirstOrDefaultAsync(x => x.QuestionId == id);

            if (q == null) return null;

            if (role != "Admin")
            {
                if (q.Status != "Approved" && q.UserId != requesterId) return null;
                // filter answers for non-admins (only approved or own)
                q.Answers = q.Answers
                    .Where(a => a.Status == "Approved" || a.UserId == requesterId)
                    .ToList();
            }

            return q;
        }

        public async Task<List<Question>> GetMyQuestionsAsync(int userId) =>
            await _db.Questions
                .Include(q => q.Images)
                .Where(q => q.UserId == userId)
                .OrderByDescending(q => q.QuestionId)
                .ToListAsync();

        private async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
            Directory.CreateDirectory(root);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(root, fileName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/uploads/{folder}/{fileName}";
        }
    }
}
