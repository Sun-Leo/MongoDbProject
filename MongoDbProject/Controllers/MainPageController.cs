using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
