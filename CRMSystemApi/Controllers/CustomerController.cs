using CRM.BusinessLayer.Abstract;
using CRM.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CRMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("CustomerList")]
        public IActionResult CustomerList()
        {
            var values =  _customerService.TGetListAll();
            return Ok(values);
        }

    }
}
