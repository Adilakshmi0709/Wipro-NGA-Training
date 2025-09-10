using System.ComponentModel.DataAnnotations;

namespace RegistrationFormMVC.Models
{
    public class Subscriber
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
