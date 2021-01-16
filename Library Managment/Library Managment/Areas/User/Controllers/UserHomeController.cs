using Library_Managment.Data;
using Library_Managment.Models;
using Microsoft.AspNetCore.Authorization;
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
        
        public UserHomeController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index() {

     
            List<Book> NewestBooks = (List<Book>)_context.Books.OrderByDescending(x => x.Id).Take(8).ToList<Book>();
            ViewBag.NewestBooks = NewestBooks;

            return View();
        }

        public IActionResult BookHistory() {


            return View();
        }

        [HttpPost]
        public IActionResult SearchBook(string searchtext) {

            List<Book> books = _context.Books.FromSqlRaw($"SELECT * FROM Books WHERE Name LIKE '%{searchtext}%' OR Author LIKE '%{searchtext}%'").ToList<Book>();
            return View("SearchResults",books);
        }

        public IActionResult BookDetails(int id) {
            return View();
        }
    }
}
