using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Api.Services.Product;
using Newtonsoft.Json;

namespace MongoDbProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:7021/api/Product");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<Models.Product>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
