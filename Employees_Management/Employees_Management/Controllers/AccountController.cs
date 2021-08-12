using Microsoft.AspNetCore.Mvc;
using Employees_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Employees_Management.Models;

namespace Employees_Management.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> _signInManager)
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

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

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

        //Custom email validation check if it used befor for an account or no
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This email {email} is already used ");
            }
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model , string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    if((!string.IsNullOrEmpty(returnUrl)) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index","home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Invalid Login");
                }
            }
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }
    }
}
