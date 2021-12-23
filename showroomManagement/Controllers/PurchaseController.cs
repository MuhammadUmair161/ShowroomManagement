using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            return View();
        }

        //// GET: Invoices/Create
        //public IActionResult _Purchase()
        //{
        //    ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
        //    ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id");
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name", Purchase.CarId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", Purchase.Vendor);
            return View();
        }

    }
}
