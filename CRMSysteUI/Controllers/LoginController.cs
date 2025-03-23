using CRMSysteUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRMSysteUI.Controllers
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
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto) 
        {
            if (ModelState.IsValid) 
            {
                var client = this._httpClientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8,"application/json");
                var response = await client.PostAsync("http://localhost:5068/api/Authentication/Login", content);

                if (response.IsSuccessStatusCode) 
                {
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            return View();

        }
    }
}
