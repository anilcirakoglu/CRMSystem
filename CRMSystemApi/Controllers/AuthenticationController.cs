using CRM.BusinessLayer.Abstract;
using CRMSystem.DtoLayer.AuthenticationDto;
using CRMSystem.EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        readonly private IConfiguration _configuration;
        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto) 
        {


            var user = _userService.GetByUsernameAndPassword(loginDto.Username, loginDto.Password);
            if (user!=null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {

                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Role, user.Role)
                 };

                var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                return Ok(token);
            }
            else
            {
                return Unauthorized("Bilgiler doğrulanamadı");
            } 
        }
      
    }
}
