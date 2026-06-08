using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
