using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Managment.Areas.User.Controllers {

    [Area("User")]
    [Authorize]
    public class UserHomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
