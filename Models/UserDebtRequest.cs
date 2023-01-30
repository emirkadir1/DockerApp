using System.ComponentModel.DataAnnotations;

namespace DockerApp.Models
{
    public class UserDebtRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public int UserDebt { get; set; }
    }
}
