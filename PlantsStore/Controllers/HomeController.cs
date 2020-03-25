using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantsStore.Models;

namespace PlantsStore.Controllers
{
    public class HomeController : Controller
    {
        PlantContext db = new PlantContext();
        public ActionResult Index()
        {
            var plants = db.Plants;
           // ViewBag.Plants = plants;
            return View(plants);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Plant plant)
        {
            db.Plants.Add(plant);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetPlant(int id)
        {
            Plant p = db.Plants.Find(id);
            if (p == null)
                return HttpNotFound();
            return View(p);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PlantId = id;
            Purchase purchase = new Purchase { PlantId = id,  Person = "Невідомо"};
            return View(purchase);
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Дякую," + purchase.Person + ", за купівлю! ";
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Plant p = db.Plants.Find(id);
            if(p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Plant p = db.Plants.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            db.Plants.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Plant plant = db.Plants.Find(id);
            if (plant != null)
            {
                return View(plant);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Plant plant)
        {
            db.Entry(plant).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}