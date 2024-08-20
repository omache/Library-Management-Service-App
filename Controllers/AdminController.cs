using LMS.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Borrowed Books: GET
        string Admin = "omacherenox@gmail.com";
        public async Task<IActionResult> Index()
        {
            return View(await _context.Borrow.ToListAsync());
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Approve(int id)
{
    var borrow = _context.Borrow.Find(id);
    if (borrow == null)
    {
        return NotFound();
    }

    borrow.IsAproved = true;
    _context.SaveChanges();

    return RedirectToAction("Index"); // Redirect back to the index page
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Reject(int id)
{
    var borrow = _context.Borrow.Find(id);
    if (borrow == null)
    {
        return NotFound();
    }

    // Assuming you have a property or method to handle rejection
    // For example, you might set a property like IsRejected = true
    _context.Borrow.Remove(borrow); // Or any other rejection logic
    _context.SaveChanges();

    return RedirectToAction("Index"); // Redirect back to the index page
}

        }
    }

