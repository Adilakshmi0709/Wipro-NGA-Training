using System.ComponentModel.DataAnnotations;

namespace DoConnect.Api.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Required(ErrorMessage = "Answer text is required")]
        public string AnswerText { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public int QuestionId { get; set; }
        public Question Question { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
