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
    public class StockController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public StockController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }


        public IActionResult Stockindex()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> StockDetail()
        {
            return View(await _context.Stocks.ToListAsync());
        }
        public async Task<IActionResult> StockDelete(int? id)
        {
            var Stocks = await _context.Stocks.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(Stocks).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("StockDetail", "Stock");
            }
            return View();
        }
        public IActionResult StockUpdate(int id)
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            var item = this._context.Stocks.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> StockUpdate(Stock stock)
        {
            this._context.Entry(stock).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("StockDetail", "Stock");
            }
            return View();
        }

        [HttpPost]
        public IActionResult _Stock(Stock stock)
        {
            if (ModelState.IsValid)
            {
                this._context.Stocks.Add(stock);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("StockDetail", "Stock");
                }
            }
            return View();
        }
    }
}
