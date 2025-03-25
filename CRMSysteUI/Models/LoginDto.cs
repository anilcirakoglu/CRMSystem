using System.ComponentModel.DataAnnotations;

namespace CRMSystemUI.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "The Username field is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The Password field is required")]
        public string Password { get; set; }
    }
}
