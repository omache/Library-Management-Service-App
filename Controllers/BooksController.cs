using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public string Admin = "omacherenox@gmail.com";

        // GET: Books
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }
            var books = from m in _context.Book
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
               books = books.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
           }
            if (!books.Any() && !String.IsNullOrEmpty(searchString))
            {
                books = from m in _context.Book
                        select m;
                books = books.Where(s => s.Publisher!.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await books.ToListAsync());
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user?.Email != Admin)
            {
                return Forbid();
            }
            else
            {
                return View();
            }

            
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Publisher,PublishYear")] Book book)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid && user?.Email == Admin )
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);

            if (user?.Email != Admin)
            {
                return Forbid();
            }
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Publisher,PublishYear")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }

        // GET: Books/Borrow
        public async Task<IActionResult> Borrow()
        {
            var borrows = await _context.Borrow.ToListAsync();
            return View(borrows);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrow(string cartData)
        {
            var user = await _userManager.GetUserAsync(User);
            if (string.IsNullOrEmpty(cartData))
            {
                // Handle case where no cart data is provided
                return RedirectToAction(nameof(Index));
            }

            var cart = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, CartItem>>(cartData);

            if (ModelState.IsValid)
            {
                
                var userBookCount = _context.Borrow.Count(e=>e.BorrowerName== user.Email);

                if (userBookCount >= 6)
                {
                    string errorMessage = "You Have reached you maximum borrow limit";
                    return NotFound(new {Message= errorMessage});
                }

                var booksAdded = 0;
                foreach (var item in cart)
                {
                    booksAdded ++;
                    var borrow = new Borrow
                    {
                        Title = item.Value.Title,
                        Quantity = item.Value.Quantity,
                        BorrowerName = user?.Email,
                        BorrowDate = DateTime.Now
                    };

                    _context.Add(borrow);
                }
                if (booksAdded+userBookCount > 6)
                {
                    return NotFound(new {Message= $"You have reached your book borrowing limit. You can only borrow upto {6-userBookCount} Book(s)"});

                }
                else 
                {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Borrow));
                }

            }

                // If validation fails, return the full list to the view
                var borrowList = await _context.Borrow.ToListAsync();
                return View(borrowList);
        }


        public class CartItem
        {
            public string Title { get; set; }
            public int Quantity { get; set; }
        }


    }
}

