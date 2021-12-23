using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewData["AccessoryId"] = new SelectList(_context.AccessoriesStocks, "Id", "AccessoryId");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _Accessory(Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                accessory.ImagePath = this.GetImage(accessory);
                this._context.Accessories.Add(accessory);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("AccessoryIndex", "Accessory");
                }
            }
            return View();
        }


        private string GetImage(Accessory accessory)
        {
            string root = "Image/";
            root += Guid.NewGuid().ToString() + accessory.Image.FileName;
            string myDir = this._webHostEnvironment.WebRootPath;
            string[] myArray = { myDir, root };
            string server = Path.Combine(myArray);
            accessory.Image.CopyTo(new FileStream(server, FileMode.Create));

            return root;
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
            ViewData["AccessoryId"] = new SelectList(_context.Accessories, "Id", "AccessoryId", accessoriesStock.AccessoryId);
            return View();
        }

    }
}
