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
using Library_Managment.Areas.Admin.Models;

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

        public async Task<IActionResult> DisplayUsers(string sortOrder, string currentFilter, string searchString, int? pageNumber) {
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

            int pageSize = 10;
            return View(await PaginatedList<UserNewData>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        
        public async Task<IActionResult> DeleteUser(string Id) {
            var user = _context.Users.First(m => m.Id == Id);

          var DeleteRows = _context.TakenBooks.Where(e => e.UserId == Id).ToList();

            foreach(var row in DeleteRows) {
                _context.TakenBooks.Remove(row);
            }

            _context.Users.Remove(user);
           await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DisplayUsers));
        }


        public async Task<IActionResult> ChangeRoles(string Role, string userId) {

            try {
                if (Role == "Admin") {
                    try {

                        var role = _userManager.FindByIdAsync(userId);

                        var user = await _userManager.FindByIdAsync(userId);

                        await _userManager.RemoveFromRoleAsync(user, "User");
                        await _userManager.AddToRoleAsync(user, "Administrator");
                    } catch (Exception e) {

                        throw e;
                    }

                } else if (Role == "User") {
                    try {

                        var role = _userManager.FindByIdAsync(userId);

                        var user = await _userManager.FindByIdAsync(userId);

                        await _userManager.RemoveFromRoleAsync(user, "Administrator");
                        await _userManager.AddToRoleAsync(user, "User");
                    } catch (Exception e) {

                        throw e;
                    }
                }
            }catch(Exception e) {

            }
            return RedirectToAction(nameof(DisplayUsers));

        }

    }
}
