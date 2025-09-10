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
    public class AnswersController : ControllerBase
    {
        private readonly AnswerService _service;
        private readonly IWebHostEnvironment _env;

        public AnswersController(AnswerService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        private int? GetUserId() =>
            int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null;

        // ✅ Post an answer (with optional image)
        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(20_000_000)] // ~20MB
        public async Task<IActionResult> Create([FromForm] AnswerDto dto)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var ans = await _service.CreateAsync(userId.Value, dto.QuestionId, dto.AnswerText, dto.Image, _env);
            if (ans == null) return NotFound(new { message = "Question not found" });

            return Ok(new { message = "Answer submitted for approval.", answerId = ans.AnswerId });
        }

        // ✅ My answers
        [HttpGet("my-answers")]
        [Authorize]
        public async Task<IActionResult> MyAnswers([FromQuery] string? status)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var query = _service.QueryMyAnswers(userId.Value);

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();
                if (!(status == "Approved" || status == "Pending" || status == "Rejected"))
                    return BadRequest(new { message = "Invalid status filter" });

                query = query.Where(a => a.Status != null && a.Status.Trim() == status);
            }

            var list = await query.ToListAsync();

            if (!list.Any()) return NotFound(new { message = "No answers found" });

            return Ok(list.Select(a => new
            {
                a.AnswerId,
                a.QuestionId,
                questionTitle = a.Question.QuestionTitle,
                text = a.AnswerText,
                status = a.Status,
                images = a.Images.Select(i => i.ImagePath)
            }));
        }
    }
}
