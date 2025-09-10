using System.ComponentModel.DataAnnotations;

namespace DoConnect.Api.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Question title is required"), MaxLength(200)]
        public string QuestionTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Question text is required")]
        public string QuestionText { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
