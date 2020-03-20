using System;
using System.Collections.Generic;
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
            ViewBag.Plants = plants;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PlantId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Дякую," + purchase.Person + ", за купівлю! ";
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