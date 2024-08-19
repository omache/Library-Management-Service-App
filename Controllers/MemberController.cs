using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
