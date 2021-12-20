using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Stock()
        {
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
                    return RedirectToAction("Inventory", "Inventory");
                }
            }
            return View();
        }
    }
}
