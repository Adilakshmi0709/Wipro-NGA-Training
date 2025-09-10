namespace DoConnect.Api.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        public int? QuestionId { get; set; }
        public Question? Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
