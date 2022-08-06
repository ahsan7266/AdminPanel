using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
