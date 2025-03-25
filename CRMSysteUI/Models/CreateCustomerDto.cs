using System.ComponentModel.DataAnnotations;

namespace CRMSystemUI.Models
{
    public class CreateCustomerDto
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "The Firstname field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Lastname field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Region field is required")]
        public string Region { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
