using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DtoLayer.CustomerDto
{
    public class GetCustomerDto
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
