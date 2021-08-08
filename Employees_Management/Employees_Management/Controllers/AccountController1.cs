using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Controllers
{
    public class AccountController1 : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
