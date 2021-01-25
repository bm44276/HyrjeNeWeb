using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Managment.Data;
using Library_Managment.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Library_Managment.Areas.Admin.Models;

namespace Library_Managment.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;
        public BooksController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment) {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Books
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["Author"] = sortOrder == "author_desc" ? "author_asc" : "author_desc";
            ViewData["Date"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";


            if (searchString != null) {
                pageNumber = 1;
            } else {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var books = from s in _context.Books
                        select s;
            if (!String.IsNullOrEmpty(searchString)) {
                books = books.Where(s => s.Author.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }
            switch (sortOrder) {
                case "name_desc":
                    books = books.OrderBy(s => s.Name);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(s => s.Author);
                    break;
                case "author_asc":
                    books = books.OrderBy(s => s.Author);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(s => s.PublishDate);
                    break;
                case "date_asc":
                    books = books.OrderBy(s => s.PublishDate);
                    break;
                default:
                    books = books.OrderBy(s => s.ISBN);
                    break;
            }

            int pageSize = 8;
            return View(await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        //
        // GET: Admin/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Admin/Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ISBN,Name,Description,Genre,Author,PublishDate,Image,Amount,Available")] BookImagePath model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "BookImages");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var book = new Book {
                    Name = model.Name,
                    ISBN = model.ISBN,
                    Description = model.Description,
                    Genre = model.Genre,
                    Author = model.Author,
                    PublishDate = model.PublishDate,
                    Image = uniqueFileName,
                    Amount = model.Amount,
                    Available = model.Available
                };

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Admin/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISBN,Name,Description,Genre,Author,PublishDate,Image,Amount,Available")] Book book)
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

        // GET: Admin/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        public async Task<IActionResult> GiveBook(string sortOrder, string currentFilter, string searchString, int? pageNumber, int id) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null) {
                pageNumber = 1;
            } else {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var users = from s in _context.Users
                        select s;
            if (!String.IsNullOrEmpty(searchString)) {
                users = users.Where(s => s.Name.Contains(searchString)
                                       || s.Surname.Contains(searchString) || s.Email.Contains(searchString) || s.UserName.Contains(searchString));
            }
            switch (sortOrder) {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.Surname);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                default:
                    users = users.OrderBy(s => s.UserName);
                    break;
            }
            ViewBag.BookId = id;
            int pageSize = 10;
            return View(await PaginatedList<UserNewData>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> GiveBookToUser(string UserId, int BookId) {

            var userNotReturnedBook = _context.TakenBooks.Where(e => e.UserId == UserId && e.Returned == false).Count();

            if (userNotReturnedBook == 0) {

                DateTime localDate = DateTime.Now;


                TakenBooks take = new TakenBooks();
                take.UserId = UserId;
                take.BookId = BookId;
                take.TakenDate = localDate;
                take.Returned = false;

                Book tempBook = _context.Books.Find(BookId);
                tempBook.Available = tempBook.Available - 1;

                _context.Books.Update(tempBook);



                await _context.TakenBooks.AddAsync(take);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else {



                return RedirectToAction(nameof(Index), new { returned = false});
            }

        }

        public IActionResult ReturnBook(int id) {
            ViewBag.BookId = id;


            List<TakenBooks> takenBooks = _context.TakenBooks.Where(e => e.BookId == id && e.Returned == false).ToList();

            List<TakenByUser> users = new List<TakenByUser>();
         

            foreach(var item in takenBooks) {
                UserNewData temp = _context.Users.Find(item.UserId);

                TakenByUser tempUser = new TakenByUser {
                    Id = temp.Id,
                    Name = temp.Name,
                    Surname = temp.Surname,
                    Email = temp.Email,
                    TakenDate = item.TakenDate
                };

                users.Add(tempUser);
            }



            return View(users);
        }

        public async Task<IActionResult> ReturnBookFromUserAsync(string UserId,int BookId) {

            TakenBooks takenBook = _context.TakenBooks.Where(e => e.BookId == BookId && e.UserId == UserId && e.Returned == false).First();
            DateTime localDate = DateTime.Now;

            takenBook.Returned = true;
            takenBook.ReturnDate = localDate;


            Book tempBook = _context.Books.Find(BookId);
            tempBook.Available = tempBook.Available + 1;


            _context.Books.Update(tempBook);
            _context.TakenBooks.Update(takenBook);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
