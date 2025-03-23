using CRMSysteUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRMSysteUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5068/api/Customer/CustomerList");
            if (responseMessage.IsSuccessStatusCode) {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CustomerDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
