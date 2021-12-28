﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string Ctokken = Url.Action("EmailConfirm", "Accounts", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);
                    ViewBag.token = Ctokken;
                    if (!string.IsNullOrEmpty(token))
                    {
                        this.sendEmailConfirm(user, token);
                    }

                    return RedirectToAction("Login", "Accounts");

                }
            }
            return View();
        }
        public async Task<IActionResult> EmailConfirm(string userId, string ctoken)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var Result = await _userManager.ConfirmEmailAsync(user, ctoken);
            if (Result!=null)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }

        private void sendEmailConfirm(ApplicationUser user, string ctoken)
        {
            //string appDomain = this._configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = Url.Action("EmailConfirm", "Accounts", new { userId = user.Id, token = ctoken }, protocol: HttpContext.Request.Scheme);

            string to = user.Email;
            string subject = "Account Confirmation";
            MailMessage mailMessage = new MailMessage();

            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = this.Htmlbody(user, confirmationLink, ctoken);
            mailMessage.From = new MailAddress("wick99185@gmail.com");
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("wick99185@gmail.com", "03092214006");

            smtpClient.Send(mailMessage);
        }
        private string Htmlbody(ApplicationUser user, string link, string ctoken)
        {
            string body = null;
            using (StreamReader reader = new StreamReader(this._webHostEnvironment.WebRootPath + "/EmailTemp/htmlpage.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("{subject}", user.FristName);
                body = body.Replace("{link}", string.Format(link, user.Id, ctoken));
            }
            return body;
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

        public IActionResult LogOut()
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
