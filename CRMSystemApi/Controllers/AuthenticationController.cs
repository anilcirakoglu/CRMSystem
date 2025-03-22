using CRM.BusinessLayer.Abstract;
using CRMSystem.DtoLayer.AuthenticationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto) 
        {
           var isValid= _userService.CheckUsernameAndPassword(loginDto.Username,loginDto.Password);
            if (isValid)
            {
                return Ok("Doğrulama başarılı");
            }
            else 
            {
                return Unauthorized("Bilgiler doğrulanamadı");
            }
        }
    }
}
