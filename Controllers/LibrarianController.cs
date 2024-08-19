using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class LibrarianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
