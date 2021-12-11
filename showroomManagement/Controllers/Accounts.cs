using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class Accounts : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public Accounts(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._webHostEnvironment = webHostEnvironment;
            this._configuration = configuration;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FullName = signUp.FullName,
                    Email = signUp.Email,
                    UserName = signUp.Email
                };
                var result = await this._userManager.CreateAsync(user, signUp.password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                   return RedirectToAction("Login", "Accounts");
                }
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await this._signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Home", "home");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Your Account iS Not Verified");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your Account has been Locked");
            }

            return View();
        }



        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
