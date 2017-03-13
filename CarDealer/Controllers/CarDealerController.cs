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
    public class CarDealerController : Controller
    {
        private CarDealerContext db = new CarDealerContext();
        // GET: CarDealer
        public ActionResult Index()
        {
            return View(db.CarDealers.ToList());
        }

        // GET: CarDealer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.CarDealer carDealer = db.CarDealers.Find(id);
            if (carDealer == null)
                return HttpNotFound();
            return View(carDealer);
        }

        // GET: CarDealer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarDealer/Create
        [HttpPost]
        public ActionResult Create(Models.CarDealer carDealer)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.CarDealers.Add(carDealer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(carDealer);
            }
            catch
            {
                return View();
            }
        }

        // GET: CarDealer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.CarDealer carDealer = db.CarDealers.Find(id);
            if (carDealer == null)
                return HttpNotFound();
            return View(carDealer);
        }

        // POST: CarDealer/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.CarDealer carDealer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(carDealer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(carDealer);

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetCarList(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.CarDealer carDealer = db.CarDealers.Find(id);
            if (carDealer == null)
                return HttpNotFound();

            //var cars = db.Cars.Where(c => c.CarDealerId == carDealer.CarDealerId);
            //CarController carController = new CarController(id);
            return Redirect("/Car/Index/" + id);

            //return View("../Car/Index",cars);
        }
    }
}
