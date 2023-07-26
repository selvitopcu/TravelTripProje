using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AboutList()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AboutGetir(int id)
        {
            var hakkmizda = c.Hakkimizdas.Find(id);
            return View("AboutGetir", hakkmizda);

        }
        [HttpPost]
        public ActionResult AboutUpdate(Hakkimizda p)
        {
            var hakk = c.Hakkimizdas.Find(p.ID);
            hakk.FotoUrl = p.FotoUrl;
            hakk.Aciklama = p.Aciklama;
            c.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutDelete(int id)
        {
            var hakkmz = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(hakkmz);
            c.SaveChanges();
            return RedirectToAction("AboutList");
        }



    }
}