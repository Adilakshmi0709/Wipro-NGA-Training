using System.Security.Claims;
using DoConnect.Api.DTOs;
using DoConnect.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoConnect.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionService _service;

        public QuestionsController(QuestionService service)
        {
            _service = service;
        }

        private (int? userId, string role) GetUser() =>
            (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null,
             User.FindFirstValue(ClaimTypes.Role) ?? "User");

        // ✅ Create question (with optional image)
        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(20_000_000)] // ~20 MB
        public async Task<IActionResult> Create([FromForm] QuestionDto dto)
        {
            var (userId, _) = GetUser();
            if (userId == null) return Unauthorized();

            var q = await _service.CreateAsync(userId.Value, dto.Title, dto.Text, dto.Image);
            return Ok(new { message = "Question submitted for approval.", questionId = q.QuestionId });
        }

        // ✅ Search approved questions (users) or all (admin)
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? query)
        {
            var (userId, role) = GetUser();
            var list = await _service.SearchAsync(query, role, userId);

            // Non-admins → filter only approved questions and answers
            if (role != "Admin")
            {
                list = list
                .Where(q => q.Status == "Approved")
                .Select(q =>
                {
                    q.Answers = q.Answers
                        .Where(a => a.Status == "Approved")
                        .ToList();
                    return q;
                })
                .ToList();
            }
            if (!list.Any())
                return NotFound(new { message = "Question not found" });

            return Ok(list.Select(q => new
            {
                q.QuestionId,
                title = q.QuestionTitle,
                text = q.QuestionText,
                status = q.Status,
                images = q.Images.Select(i => i.ImagePath),
                answers = q.Answers.Select(a => new
                {
                    a.AnswerId,
                    text = a.AnswerText,
                    status = a.Status,
                    images = a.Images.Select(i => i.ImagePath)
                })
            }));
        }

 
        // ✅ Get by Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var (userId, role) = GetUser();
            var q = await _service.GetByIdAsync(id, role, userId);
            if (q == null) return NotFound(new { message = "Question not found" });

            return Ok(new
            {
                q.QuestionId,
                title = q.QuestionTitle,
                text = q.QuestionText,
                status = q.Status,
                user = new { q.User.Username, q.UserId },
                images = q.Images.Select(i => i.ImagePath),
                answers = q.Answers.Select(a => new
                {
                    a.AnswerId,
                    text = a.AnswerText,
                    status = a.Status,
                    userId = a.UserId,
                    images = a.Images.Select(i => i.ImagePath)
                })
            });
        }

        // ✅ My Questions
        [HttpGet("my-questions")]
        [Authorize]
        public async Task<IActionResult> MyQuestions([FromQuery] string? status)
        {
            var (userId, _) = GetUser();
            if (userId == null) return Unauthorized();

            var query = _service.QueryMyQuestions(userId.Value).AsQueryable();
            query = query
                    .Include(q => q.Images)
                    .Include(q => q.Answers)
                    .ThenInclude(a => a.Images);

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();
                if (!(status == "Approved" || status == "Pending" || status == "Rejected"))
                    return BadRequest(new { message = "Invalid status filter" });

                query = query.Where(q => q.Status != null && q.Status.Trim() == status);
            }

            var list = await query.ToListAsync();

            if (!list.Any()) return NotFound(new { message = "No questions found" });

            return Ok(list.Select(q => new
            {
                q.QuestionId,
                title = q.QuestionTitle,
                text = q.QuestionText,
                status = q.Status,
                images = q.Images.Select(i => i.ImagePath),
                answers = q.Answers.Select(a => new
                {
                    a.AnswerId,
                    text = a.AnswerText,
                    status = a.Status,
                    images = a.Images.Select(i => i.ImagePath)
                })
            }));
        }

    }
}
