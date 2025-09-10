using System.ComponentModel.DataAnnotations;

namespace DoConnect.Api.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required"), MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required"), MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required"), MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required"), EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required"), MinLength(8), MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required] public string Role { get; set; } = "User";
        
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
