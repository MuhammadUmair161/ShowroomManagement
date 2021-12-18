using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{

    public class AccessoryController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public AccessoryController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }
        public IActionResult AccessoryIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult _Accessory(Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                this._context.Accessories.Add(accessory);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _AccessoriesStock(AccessoriesStock accessoriesStock)
        {
            if (ModelState.IsValid)
            {
                this._context.AccessoriesStocks.Add(accessoriesStock);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }

    }
}
