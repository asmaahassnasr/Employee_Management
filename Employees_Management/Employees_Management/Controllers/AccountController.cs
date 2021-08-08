using Microsoft.AspNetCore.Mvc;
using Employees_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Employees_Management.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager , SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if(ModelState.IsValid)
            {

                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var result = await userManager.CreateAsync(user,model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("index","home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }

            }
                return  View(model);
            
        }
    }
}
