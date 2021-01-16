using Library_Managment.Data;
using Library_Managment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Managment.Areas.User.Controllers {

    [Area("User")]
    [Authorize]
    public class UserHomeController : Controller {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserNewData> _userManager;
        public UserHomeController(ApplicationDbContext context,UserManager<UserNewData> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index() {

     
            List<Book> NewestBooks = (List<Book>)_context.Books.OrderByDescending(x => x.Id).Take(8).ToList<Book>();
            ViewBag.NewestBooks = NewestBooks;

            return View();
        }

        public async Task<IActionResult> BookHistoryAsync() {


            var current = await _userManager.GetUserAsync(User);

            var userRows = _context.TakenBooks.OrderByDescending(x => x.Id).Where(x => x.UserId == current.Id);


            List<Book> books = new List<Book>();


            foreach (var row in userRows) {
                var book = _context.Books.Find(row.BookId);
                books.Add(book);
            }

            return View(books);
        }

        [HttpPost]
        public IActionResult SearchBook(string searchtext) {

            List<Book> books = _context.Books.FromSqlRaw($"SELECT * FROM Books WHERE Name LIKE '%{searchtext}%' OR Author LIKE '%{searchtext}%'").ToList<Book>();
            return View("SearchResults",books);
        }

        public IActionResult BookDetails(int id) {
            Book book = _context.Books.Find(id);
            return View(book);
        }
    }
}
