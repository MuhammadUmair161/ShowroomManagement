﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class CarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShrowroomDbContext _context;
        public CarController(ShrowroomDbContext context, IWebHostEnvironment WebHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = WebHostEnvironment;
        }
        // GET: cars
        public ActionResult newCar()
        {
            return View();
        }
        public ActionResult _CarPv()
        {
            return View();
        }

        public IActionResult CarIndex()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            ViewData["CarTypeId"] = new SelectList(_context.CarTypes,"Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies,"Id", "Name");
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> _Car(Car car)
        {
            if (ModelState.IsValid)
            {
                if(car.Image1!=null)
                {
                    car.CarImage1 = this.GetImage(car);
                }
                this._context.Cars.Add(car);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }
        private string GetImage(Car car)
        {
            string root = "Image/";
            root += Guid.NewGuid().ToString() + car.Image1.FileName;
            string myDir = this._webHostEnvironment.WebRootPath;
            string[] myArray = { myDir, root };
            string server = Path.Combine(myArray);
            car.Image1.CopyTo(new FileStream(server, FileMode.Create));

            return root;
        }

        [HttpPost]
        public IActionResult _CarType(CarType carType)
        {
            if (ModelState.IsValid)
            {
                this._context.CarTypes.Add(carType);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _Company(Company company)
        {
            if (ModelState.IsValid)
            {
                this._context.Companies.Add(company);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _NewCar(NewCar newCar)
        {
            if (ModelState.IsValid)
            {
                this._context.NewCars.Add(newCar);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _UsedCar(UsedCar usedCar)
        {
            if (ModelState.IsValid)
            {
                this._context.UsedCars.Add(usedCar);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult _RegisteredCar(RegisteredCar registered)
        {
            if (ModelState.IsValid)
            {
                this._context.RegisteredCars.Add(registered);
                if (this._context.SaveChanges() > 0)
                {
                    return RedirectToAction("CarIndex", "Car");
                }
            }
            return View();
        }

        [HttpPost]
        public string myAction(Car car)
        {
            return "";
        }



        // GET: cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cars/Create
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

        // GET: cars/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: cars/Edit/5
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

        // GET: cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: cars/Delete/5
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
