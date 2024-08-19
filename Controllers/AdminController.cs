using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET The Add DATA

        public IActionResult AddBook()
        {
            return View();
        }


    }
}
