using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DockerApp.Models
{
    public class UserRegisterRequest
    {
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Lütfen En az 6 karakter girin.")]
        public string Password { get; set; } = string.Empty;
        [Required,Compare("Password", ErrorMessage = "Lütfen doğru şifre giriniz.")]
        public string ConfirmPassword {get; set;} = string.Empty;
    }
}
