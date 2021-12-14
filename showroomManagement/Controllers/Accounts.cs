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
                    FristName = signUp.FristName,
                    LastName = signUp.LastName,
                    Email = signUp.Email,
                    UserName = signUp.Email,
                };
                var result = await this._userManager.CreateAsync(user, signUp.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return RedirectToAction("index", "home");
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
                return RedirectToAction("index", "home");
            }

            return View();
        }



        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
