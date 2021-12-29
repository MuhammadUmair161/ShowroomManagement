using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> newCar()
        {
            var shrowroomDbContext = _context.NewCars.Include(n => n.Car).Include(n=>n.Car.CarType).Include(n => n.Car.Company);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public async Task<IActionResult> UsedCar()
        {
            var shrowroomDbContext = _context.UsedCars.Include(n => n.Car).Include(n => n.Car.CarType).Include(n => n.Car.Company);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public ActionResult _CarPv()
        {
            return View();
        }
        public ActionResult _UsedCarPv()
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
            return RedirectToAction("CarIndex", "Car");
        }
        public async Task<IActionResult> CarDetail()
        {
            var shrowroomDbContext = _context.Cars.Include(c => c.CarType).Include(c => c.Company);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public async Task<IActionResult> CarDelete(int? id)
        {
            var car = await _context.Cars.FindAsync(id);
            this._context.Entry(car).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("CarDetail", "Car");
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
        public async Task<IActionResult> CarTypeDetail()
        {
            return View(await _context.CarTypes.ToListAsync());
        }
        public async Task<IActionResult> CarTypeDelete(int? id)
        {
            var CarType = await _context.CarTypes.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(CarType).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("CarTypeDetail", "Car");
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
        public async Task<IActionResult> CompanyDetail()
        {
            return View(await _context.Companies.ToListAsync());
        }
        public async Task<IActionResult> CompanyDelete(int? id)
        {
            var Company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(Company).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("CompanyDetail", "Car");
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
                    return RedirectToAction("newCar", "Car");
                }
            }
            return View();
        }
        public IActionResult NewCarUpdate(int id)
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            var item = this._context.NewCars.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> NewCarUpdate(NewCar newCar)
        {
            this._context.Entry(newCar).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("NewCarDetail", "car");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NewCarDetail()
        {
            var shrowroomDbContext = _context.NewCars.Include(n => n.Car);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public async Task<IActionResult> NewCarDelete(int? id)
        {
            var NewCar = await _context.NewCars.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(NewCar).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("NewCarDetail", "Car");
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
                    return RedirectToAction("UsedCar", "Car");
                }
            }
            return View();
        }
        public IActionResult UsedCarUpdate(int id)
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Name");
            var item = this._context.UsedCars.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> UsedCarUpdate(UsedCar usedCar)
        {
            this._context.Entry(usedCar).State = EntityState.Modified;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("UsedCarDetail", "car");
            }
            return View();
        }

        public async Task<IActionResult> UsedCarDetail()
        {
            var shrowroomDbContext = _context.UsedCars.Include(n => n.Car);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public async Task<IActionResult> UsedCarDelete(int? id)
        {
            var UsedCar = await _context.UsedCars.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(UsedCar).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("UsedCarDetail", "Car");
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
        public async Task<IActionResult> RegisteredCarDetail()
        {
            var shrowroomDbContext = _context.RegisteredCars.Include(n => n.Car);
            return View(await shrowroomDbContext.ToListAsync());
        }
        public async Task<IActionResult> RegisteredCarDelete(int? id)
        {
            var RegisteredCar = await _context.RegisteredCars.FirstOrDefaultAsync(m => m.Id == id);
            this._context.Entry(RegisteredCar).State = EntityState.Deleted;
            if (await this._context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("RegisteredCarDetail", "car");
            }
            return View();
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
