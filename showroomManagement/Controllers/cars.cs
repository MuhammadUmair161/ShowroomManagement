using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Controllers
{
    public class cars : Controller
    {
        // GET: cars
        public ActionResult newCar()
        {
            return View();
        }
        public ActionResult CarPv()
        {
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
