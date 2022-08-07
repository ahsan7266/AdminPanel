using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddPortfolioDetail()
        {
            return View();
        }
    }
}
