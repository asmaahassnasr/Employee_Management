using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Controllers
{
    public class AdminstrationController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public AdminstrationController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
    }
}
