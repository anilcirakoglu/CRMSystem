using CRMSystemUI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRMSystemUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5068/api/Authentication/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    if (data != null)
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(data);

                        var claims = token.Claims.ToList();
                        if (data != null)
                            claims.Add(new Claim("accesToken", data));

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        }

                        return RedirectToAction("Index", "Customer");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
          return RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); 
        }
    }
}
