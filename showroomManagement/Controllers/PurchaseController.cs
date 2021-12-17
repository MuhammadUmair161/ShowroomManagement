using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public PurchaseController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }



        public IActionResult PurchaseIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult _Purchase(Purchase Purchase)
        {
            if (ModelState.IsValid)
            {
                this._context.Purchases.Add(Purchase);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("PurchaseIndex", "Purchase");
                }
            }
            return View();
        }

    }
}
