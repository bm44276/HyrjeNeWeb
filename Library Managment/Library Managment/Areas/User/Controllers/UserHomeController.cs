using Library_Managment.Data;
using Library_Managment.Models;
using Library_Managment.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakenBooks = Library_Managment.Areas.User.Models.TakenBooks;
using Library_Managment.Data.Migrations;
using Library_Managment.Models;
using Library_Managment.Areas.Admin.Models;


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

        public async Task<IActionResult> IndexAsync(string sortOrder, string currentFilter,string searchString, int? pageNumber) {

     
            List<Book> NewestBooks = (List<Book>)_context.Books.OrderByDescending(x => x.Id).Take(8).ToList<Book>();
            ViewBag.NewestBooks = NewestBooks;

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           /* ViewData["Author"] = sortOrder == "author_desc" ? "author_asc" : "author_desc";*/
            ViewData["Drama"] = sortOrder == "Drama" ? "Drama" : "Drama";
            ViewData["Romance"] = sortOrder == "Romance" ? "Romance" : "Romance";
            ViewData["Thriller"] = sortOrder == "Thriller" ? "Thriller" : "Thriller";
            ViewData["Biography"] = sortOrder == "Biography" ? "Biography" : "Biography";

            var books = from s in _context.Books
                        select s;
            switch (sortOrder) {
                case "Drama":
                    books = books.Where(s => s.Genre == "Drama") ;
                    break;
                case "Thriller":
                    books = books.Where(s => s.Genre == "Thriller");
                    break;
                case "Biography":
                    books = books.Where(s => s.Genre == "Biography");
                    break;
                case "Romance":
                    books = books.Where(s => s.Genre == "Romance");
                    break;
                default:
                    books = books;
                    break;
            }

            int pageSize = 8;
            return View(await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> BookHistoryAsync() {


            var current = await _userManager.GetUserAsync(User);

            var userRows = _context.TakenBooks.OrderByDescending(x => x.Id).Where(x => x.UserId == current.Id);


            List<TakenBooks> books = new List<TakenBooks>();


            foreach (var row in userRows) {
                var book = _context.Books.Find(row.BookId);

                TakenBooks temp = new TakenBooks {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    Name = book.Name,
                    Description = book.Description,
                    Genre = book.Genre,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Image = book.Image,
                    Amount = book.Amount,
                    Available = book.Available,
                    TakenDate = row.TakenDate,
                    ReturnDate = row.ReturnDate
                };

                books.Add(temp);
            }

            return View(books);
        }

        [HttpPost]
        public IActionResult SearchBook(string searchtext) {
           
            List<Book> books = _context.Books.FromSqlRaw($"SELECT * FROM Books WHERE Name LIKE '%{searchtext}%' OR Author LIKE '%{searchtext}%'").ToList<Book>();

           if(books.Count == 0) {
                return View("404");
            }

            return View("SearchResults",books);
        }

        public IActionResult BookDetails(int id) {
            Book book = _context.Books.Find(id);
            return View(book);
        }
    }
}
