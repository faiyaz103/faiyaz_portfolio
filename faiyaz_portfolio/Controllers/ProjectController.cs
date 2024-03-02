using Microsoft.AspNetCore.Mvc;

namespace faiyaz_portfolio.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
