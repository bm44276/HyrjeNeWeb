using Library_Managment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library_Managment.Models;
using Microsoft.EntityFrameworkCore;
using Library_Managment.Data;

namespace Library_Managment.Controllers {
    public class HomeController : Controller {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public void Index() {
            //Response.Redirect("Identity/Account/Login");
            Response.Redirect("User");

        }

        public IActionResult ContactUs() {
            return View();
        }
        
        public IActionResult About() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Name,Subject,Email,Message")] Contact contact) {
            if (ModelState.IsValid) {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("ContactUs");
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
