using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
