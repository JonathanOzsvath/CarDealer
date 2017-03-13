using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Context;
using CarDealer.Models;

namespace CarDealer.Controllers
{
    public class CarController : Controller
    {
        public CarDealerContext db = new CarDealerContext();

        // GET: Car
        public ActionResult Index(int? CarDealerId)
        {
            if (CarDealerId == null)
                return HttpNotFound();
            var cars = db.Cars.Where(c => c.CarDealerId == CarDealerId);
            Variables.CarDealerID = (int) CarDealerId;
            return View(cars.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Car car = db.Cars.Find(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(Car car)
        {
            string url = Request.Url.AbsolutePath;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { CarDealerId = Variables.CarDealerID });
                }
                return View(car);
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Car car= db.Cars.Find(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            car.CarDealerId = Variables.CarDealerID;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index/" + Variables.CarDealerID);
                }
                return View(car);
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Car car = db.Cars.Find(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Car car = new Car();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    car = db.Cars.Find(id);
                    if (car == null)
                        return HttpNotFound();
                    db.Cars.Remove(car);
                    db.SaveChanges();
                    return RedirectToAction("Index/" + Variables.CarDealerID);
                }
                return View(car);
            }
            catch
            {
                return View();
            }
        }
    }
}
