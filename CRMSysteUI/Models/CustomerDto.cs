using System.ComponentModel.DataAnnotations;

namespace CRMSystemUI.Models
{
    public class CustomerDto
    {

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public DateTime RegistrationDate { get; set; }= DateTime.Now.ToUniversalTime();
    }
}
