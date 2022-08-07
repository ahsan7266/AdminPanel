using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return Redirect("/Account/Login");
            }
            ViewBag.Name = HttpContext.Session.GetString("FirstName") + ' ' + HttpContext.Session.GetString("LastName");
            return View();
        }
    }
}
