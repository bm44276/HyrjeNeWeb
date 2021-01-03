using Library_Managment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Managment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment.Areas.Admin.Controllers {

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminHomeController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserNewData> _userManager;
        public AdminHomeController(ApplicationDbContext context, UserManager<UserNewData> userManager) {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult SearchUser(string search) {
            
            List<UserNewData> users = _context.Users.FromSqlRaw($"SELECT * FROM AspNetUsers WHERE Name LIKE '%{search}%' OR Surname LIKE '%{search}%' OR UserName LIKE '%{search}%'").ToList<UserNewData>();
            return View("DisplayUsers", users);
        }

        public async Task<IActionResult> DisplayUsers() {

          List<UserNewData>users = _context.Users.ToList<UserNewData>();

            return View(users);
        }
      

        public async Task<IActionResult> DeleteUser(string Id) {
            var user = _context.Users.First(m => m.Id == Id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(DisplayUsers));
        }
        /*
         IDBSet inherits from IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, and IEnumerable, so you can't directly cast it to a list that way. You could get a List<TEntity> of all entities in the DBSet though by using .ToList() or .ToListAsync()

THis creates a copy of all entities in memory though, so you should consider operating with LINQ directly on the DBSet
        https://stackoverflow.com/questions/30845579/how-to-cast-dbsett-to-listt

        https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio


        https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio


        https://stackoverflow.com/questions/32512169/change-layout-based-on-type-of-user-role
You just need to modify the /Views/_ViewStart.cshtml file.

@{
    if (this.User.IsInRole("Admin") || !this.User.Identity.IsAuthenticated) {
        Layout = "~/Views/Shared/_Layout.cshtml"; 
    } else {
        Layout = "~/Views/Shared/_LayoutUser.cshtml";
    }
}




         */
    }
}
