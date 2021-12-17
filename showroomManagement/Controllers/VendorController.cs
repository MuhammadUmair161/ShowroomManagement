using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class VendorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public VendorController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }


        public IActionResult VendorIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult _Vendor(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                this._context.Vendors.Add(vendor);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("VendorIndex", "vendor");
                }
            }
            return View();
        }

    }
}
