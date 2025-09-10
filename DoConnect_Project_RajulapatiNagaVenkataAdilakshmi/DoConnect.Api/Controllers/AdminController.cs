using System.Security.Claims;
using DoConnect.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly DoConnectDbContext _db;
        public AdminController(DoConnectDbContext db) { _db = db; }

        [HttpPatch("questions/{id:int}/status")]
        public async Task<IActionResult> UpdateQuestionStatus(int id, [FromBody] Dictionary<string, string> body)
        {
            if (!body.TryGetValue("status", out var status)) return BadRequest(new { message = "Status is required" });
            if (!(status == "Approved" || status == "Rejected" || status == "Pending"))
                return BadRequest(new { message = "Invalid status" });

            var q = await _db.Questions.FindAsync(id);
            if (q == null) return NotFound(new { message = "Question not found" });

            q.Status = status;
            await _db.SaveChangesAsync();
            return Ok(new { message = "Question status updated" });
        }

        [HttpPatch("answers/{id:int}/status")]
        public async Task<IActionResult> UpdateAnswerStatus(int id, [FromBody] Dictionary<string, string> body)
        {
            if (!body.TryGetValue("status", out var status)) return BadRequest(new { message = "Status is required" });
            if (!(status == "Approved" || status == "Rejected" || status == "Pending"))
                return BadRequest(new { message = "Invalid status" });

            var a = await _db.Answers.FindAsync(id);
            if (a == null) return NotFound(new { message = "Answer not found" });

            a.Status = status;
            await _db.SaveChangesAsync();
            return Ok(new { message = "Answer status updated" });
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions([FromQuery] string? status)
        {
            var query = _db.Questions
                .Include(q => q.User)
                .Include(q => q.Images)
                .Include(q => q.Answers)
                .ThenInclude(a => a.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();
                if (!(status == "Approved" || status == "Rejected" || status == "Pending"))
                    return BadRequest(new { message = "Invalid status filter" });

                query = query.Where(q => q.Status != null && q.Status.Trim() == status);
            }

            var questions = await query.ToListAsync();

            if (!questions.Any())
                return NotFound(new { message = "No questions found" });

            return Ok(questions.Select(q => new
            {
                q.QuestionId,
                title = q.QuestionTitle,
                text = q.QuestionText,
                status = q.Status,
                user = new { q.UserId, q.User.Username },
                images = q.Images.Select(i => i.ImagePath),
                answers = q.Answers.Select(a => new
                {
                    a.AnswerId,
                    text = a.AnswerText,
                    status = a.Status,
                    userId = a.UserId,
                    images = a.Images.Select(i => i.ImagePath)
                })
            }));
        }

        [HttpGet("answers")]
        public async Task<IActionResult> GetAllAnswers([FromQuery] string? status)
        {
            var query = _db.Answers
                .Include(a => a.User)
                .Include(a => a.Question)
                .Include(a => a.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();
                if (!(status == "Approved" || status == "Rejected" || status == "Pending"))
                    return BadRequest(new { message = "Invalid status filter" });

                query = query.Where(a => a.Status != null && a.Status.Trim() == status);
            }

            var answers = await query.ToListAsync();

            if (!answers.Any())
                return NotFound(new { message = "No answers found" });

            return Ok(answers.Select(a => new
            {
                a.AnswerId,
                text = a.AnswerText,
                status = a.Status,
                user = new { a.UserId, a.User.Username },
                question = new { a.QuestionId, a.Question.QuestionTitle },
                images = a.Images.Select(i => i.ImagePath)
            }));
        }

        [HttpDelete("questions/{id:int}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var q = await _db.Questions
                .Include(x => x.Images)
                .Include(x => x.Answers).ThenInclude(a => a.Images)
                .FirstOrDefaultAsync(x => x.QuestionId == id);

            if (q == null) return NotFound(new { message = "Question not found" });

            foreach (var img in q.Images)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", img.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            foreach (var ans in q.Answers)
            {
                foreach (var img in ans.Images)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", img.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                }
            }
            _db.Questions.Remove(q);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Question and related answers deleted" });
        }

        [HttpDelete("answers/{id:int}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var a = await _db.Answers.Include(x => x.Images).FirstOrDefaultAsync(x => x.AnswerId == id);
            if (a == null) return NotFound(new { message = "Answer not found" });

            foreach (var img in a.Images)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", img.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }

            _db.Answers.Remove(a);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Answer deleted" });
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.Users
                .Select(u => new { u.UserId, u.FirstName, u.LastName, u.Username, u.Email, u.Role })
                .ToListAsync();

            return Ok(users);
        }

        [HttpPatch("users/{id:int}/role")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] Dictionary<string, string> body)
        {
            if (!body.TryGetValue("role", out var role)) return BadRequest(new { message = "Role is required" });
            var u = await _db.Users.FindAsync(id);
            if (u == null) return NotFound(new { message = "User not found" });
            u.Role = role;
            await _db.SaveChangesAsync();
            return Ok(new { message = "User role updated" });
        }

        [HttpDelete("users/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var u = await _db.Users.FindAsync(id);
            if (u == null) return NotFound(new { message = "User not found" });
            _db.Users.Remove(u);
            await _db.SaveChangesAsync();
            return Ok(new { message = "User removed" });
        }
    }
}
