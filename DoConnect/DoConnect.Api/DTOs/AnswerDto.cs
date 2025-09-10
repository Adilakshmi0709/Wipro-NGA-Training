using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace DoConnect.Api.DTOs
{
    public class AnswerDto
    {
        [Required(ErrorMessage = "Question ID is required")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Answer text is required")]
        public string AnswerText { get; set; } = string.Empty;

        [FileExtensions(Extensions = "jpg,jpeg,png,gif,webp", ErrorMessage = "Only image files are allowed.")]
        public IFormFile? Image { get; set; }
    }
}
