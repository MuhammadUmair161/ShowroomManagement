using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> VendorDetail()
        {
            return View(await _context.Vendors.ToListAsync());
        }

        public async Task<IActionResult> VendorDelete(int? id)
        {
            var Vendor = await _context.Vendors.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(Vendor).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("VendorDetail", "Vendor");
            }
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
