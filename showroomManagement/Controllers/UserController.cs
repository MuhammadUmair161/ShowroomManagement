using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public UserController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }

        public IActionResult CustomerDetailIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerDetail(CustomerDetail customer)
        {
            if (ModelState.IsValid)
            {
                this._context.CustomerDetails.Add(customer);
                if (this._context.SaveChanges() > 0)
                {
                    //return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }
        public IActionResult OrderDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _Order(Order order)
        {
            if (ModelState.IsValid)
            {
                this._context.Orders.Add(order);
                if (this._context.SaveChanges() > 0)
                {
                    //return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _Interst(Interst interst)
        {
            if (ModelState.IsValid)
            {
                this._context.Intersts.Add(interst);
                if (this._context.SaveChanges() > 0)
                {
                    //return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }

    }
}
