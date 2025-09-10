using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace DoConnect.Api.DTOs
{
    public class QuestionDto
    {
        [Required(ErrorMessage = "Question title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Question text is required")]
        public string Text { get; set; } = string.Empty;

        [FileExtensions(Extensions = "jpg,jpeg,png,gif,webp", ErrorMessage = "Only image files are allowed.")]
        public IFormFile? Image { get; set; }
    }
}
