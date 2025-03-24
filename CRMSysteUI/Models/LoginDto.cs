using System.ComponentModel.DataAnnotations;

namespace CRMSystemUI.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }
    }
}
