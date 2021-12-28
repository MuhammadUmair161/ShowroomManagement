using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public AccessoriesController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }
        public IActionResult AccessoryIndex()
        {
            ViewData["AccessoryId"] = new SelectList(_context.Accessories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _Accessory(Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                if (accessory.Image != null)
                {
                    accessory.ImagePath = this.GetImage(accessory);
                }
                this._context.Accessories.Add(accessory);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("AccessoriesIndex", "Accessories");
                }
            }
            return View();
        }

        public async Task<IActionResult> AccessoryDetail()
        {
            return View(await _context.Accessories.ToListAsync());
        }

        public IActionResult AccessoryUpdate(int id)
        {
            var item = this._context.Accessories.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> AccessoryUpdate(Accessory accessory)
        {
            if (accessory.Image != null)
            {
                accessory.ImagePath = this.GetImage(accessory);
            }
            this._context.Entry(accessory).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("AccessoryDetail", "Accessories");
            }
            return View();
        }
        public async Task<IActionResult> AccessoryDelete(int? id)
        {
            var accessory = await _context.Accessories.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(accessory).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("AccessoryDetail", "Accessories");
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
        public async Task<IActionResult> _AccessoriesStock(AccessoriesStock accessoriesStock)
        {
            if (ModelState.IsValid)
            {
                this._context.AccessoriesStocks.Add(accessoriesStock);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("AccessoriesStockDetail", "Accessories");
                }
            }
            return View();
        }
        public async Task<IActionResult> AccessoriesStockDetail()
        {
            ViewData["AccessoryId"] = new SelectList(_context.Accessories, "Id", "Name");
            return View(await _context.AccessoriesStocks.ToListAsync());
        }

        public IActionResult AccessoriesStockUpdate(int id)
        {
            ViewData["AccessoryId"] = new SelectList(_context.Accessories, "Id", "Name");
            var item = this._context.AccessoriesStocks.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> AccessoriesStockUpdate(AccessoriesStock accessoriesStock)
        {
            this._context.Entry(accessoriesStock).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("AccessoriesStockDetail", "Accessories");
            }
            return View();
        }

        public async Task<IActionResult> AccessoriesStockDelete(int? id)
        {
            var accessoriesStock = await _context.AccessoriesStocks.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(accessoriesStock).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("AccessoriesStockDetail", "Accessories");
            }
            return View();
        }


    }
}
