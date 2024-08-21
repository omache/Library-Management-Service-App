using LMS.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Security;

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
public async Task<IActionResult> Approve(int id)
{
    var borrow = await _context.Borrow.FindAsync(id);
    var book = await _context.Book.FirstOrDefaultAsync(b=>b.Title==borrow.Title);
    if (borrow == null)
    {
        return NotFound();
    }

    if (book.Quantity > 0)
    {  
         if(book.Quantity >= borrow.Quantity)
        {
            borrow.IsAproved = true;
            book.Quantity -= borrow.Quantity;
            await _context.SaveChangesAsync();
        }
        else
        {
            borrow.Quantity = book.Quantity;
            book.Quantity -= borrow.Quantity;
            borrow.IsAproved = true;
            await _context.SaveChangesAsync();
        }

    }
    else
    {
        return NotFound(new{Message="This book is not on stock at the moment"} );

    }

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

        //Admin/BorrowersList GET:

        public async Task<IActionResult> BorrowersList()
        {
            var approvedBorrowers = await _context.Borrow.Where(u=> u.IsAproved==true).ToListAsync();
            return View(approvedBorrowers);
        }


        //Admin Returned/ GET
        public async Task<IActionResult> Return()
        {
            var borrows = await _context.Borrow.ToListAsync();
            return View(borrows);
        }

    }
}

