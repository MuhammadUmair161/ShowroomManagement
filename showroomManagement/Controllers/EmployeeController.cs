using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public EmployeeController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }

        public IActionResult EmployeeIndex()
        {
            return View();
        }


        // GET: EmployeeController
        public async Task<IActionResult> EmployeeDetail()
        {
            return View(await _context.Employees.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> _Employee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ImagePath = this.GetImage(employee);
                this._context.Employees.Add(employee);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("EmployeeIndex", "Employee");
                }
            }
            return View();
        }

        private string GetImage(Employee employee)
        {
            string root = "Image/";
            root += Guid.NewGuid().ToString() + employee.Image.FileName;
            string myDir = this._webHostEnvironment.WebRootPath;
            string[] myArray = { myDir, root };
            string server = Path.Combine(myArray);
            employee.Image.CopyTo(new FileStream(server, FileMode.Create));

            return root;
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
        public IActionResult EmployeeUpdate(int id)
        {
            var item = this._context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        // GET: EmployeeController/Edit/5
        [HttpPost]
        public async Task<IActionResult> EmployeeUpdate(Employee employee)
        {
            employee.ImagePath = this.GetImage(employee);
            this._context.Entry(employee).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("EmployeeDetail", "Employee");
            }
            return View();
        }

        // POST: EmployeeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> _EmployeeUpdate(int id, IFormCollection collection)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> EmployeeDelete(int? id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(employee).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("EmployeeDetail", "Employee");
            }
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
