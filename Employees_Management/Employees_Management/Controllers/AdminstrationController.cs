using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Employees_Management.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Employees_Management.Models;

namespace Employees_Management.Controllers
{
    public class AdminstrationController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminstrationController(RoleManager<IdentityRole> _roleManager , UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = model.Name };
                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("index","home");
                }
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {id} Not Found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel { Id = role.Id, RoleName = role.Name };

            foreach (var user in userManager.Users.ToList())
            {
                if( await userManager.IsInRoleAsync(user,role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }
    }
}
