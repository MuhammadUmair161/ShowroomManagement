﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult _EmployeeList()
        {
            var list = this._context.Employees.ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult _Employee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //employee.ImagePath = this.GetImage(employee);
                this._context.Employees.Add(employee);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("EmployeeIndex", "Employee");
                }
            }
            return View();
        }

        //private string GetImage(Employee employee)
        //{
        //    string root = "Image/";
        //    root += Guid.NewGuid().ToString() + employee.Image.FileName;
        //    string myDir = this._webHostEnvironment.WebRootPath;
        //    string[] myArray = { myDir, root };
        //    string server = Path.Combine(myArray);
        //    employee.Image.CopyTo(new FileStream(server, FileMode.Create));

        //    return root;
        //}

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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
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
