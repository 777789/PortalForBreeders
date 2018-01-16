using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;
using PagedList;

namespace EndToEnd.Controllers
{
    public class TrzodaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trzoda
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CenaSortParm = String.IsNullOrEmpty(sortOrder) ? "Cena" : "";
            ViewBag.BialkoSortParm = sortOrder == "Bialko" ? "bialko_desc" : "Bialko";
            ViewBag.EnergiaSortParm = sortOrder == "Energia" ? "Energia_desc" : "Energia";
            ViewBag.TluszczeSortParm = sortOrder == "Tluszcze" ? "Tluszcze_desc" : "Tluszcze";
            ViewBag.WapnSortParm = sortOrder == "Wapn" ? "Wapn_desc" : "Wapn";
            ViewBag.FosforSortParm = sortOrder == "Fosfor" ? "Fosfor_desc" : "Fosfor";
            ViewBag.SodSortParm = sortOrder == "Sod" ? "Sod_desc" : "Sod";
            ViewBag.MagnezSortParm = sortOrder == "Magnez" ? "Magnez_desc" : "Magnez";
            ViewBag.LizynaSortParm = sortOrder == "Lizyna" ? "Lizyna_desc" : "Lizyna";
            ViewBag.MetioninaSortParm = sortOrder == "Metionina" ? "Metionina_desc" : "Metionina";
            ViewBag.TreoinaSortParm = sortOrder == "Treoina" ? "Treoina_desc" : "Treoina";
            ViewBag.ArgininaSortParm = sortOrder == "Arginina" ? "Arginina_desc" : "Arginina";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Bsort = from s in db.TrzodaProducts
                        select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                Bsort = db.TrzodaProducts.Where(s => s.Wiek.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Cena":
                    Bsort = Bsort.OrderByDescending(s => s.Cena);
                    break;
                case "Bialko":
                    Bsort = Bsort.OrderBy(s => s.Bialko);
                    break;
                case "bialko_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Bialko);
                    break;
                case "Energia":
                    Bsort = Bsort.OrderBy(s => s.Energia);
                    break;
                case "Energia_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Energia);
                    break;
                case "Tluszcze":
                    Bsort = Bsort.OrderBy(s => s.Tluszcze);
                    break;
                case "Tluszcze_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Tluszcze);
                    break;
                case "Wapn":
                    Bsort = Bsort.OrderBy(s => s.Wapn);
                    break;
                case "Wapn_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Wapn);
                    break;
                case "Sod":
                    Bsort = Bsort.OrderBy(s => s.Sod);
                    break;
                case "Sod_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Sod);
                    break;
                case "Magnez":
                    Bsort = Bsort.OrderBy(s => s.Magnez);
                    break;
                case "Magnez_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Magnez);
                    break;
                case "Fosfor":
                    Bsort = Bsort.OrderBy(s => s.Fosfor);
                    break;
                case "Fosfor_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Fosfor);
                    break;
                case "Lizyna":
                    Bsort = Bsort.OrderBy(s => s.Lizyna);
                    break;
                case "Lizyna_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Lizyna);
                    break;
                case "Metionina":
                    Bsort = Bsort.OrderBy(s => s.Metionina);
                    break;
                case "Metionina_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Metionina);
                    break;
                case "Treoina":
                    Bsort = Bsort.OrderBy(s => s.Treonina);
                    break;
                case "Treoina_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Treonina);
                    break;
                case "Arginina":
                    Bsort = Bsort.OrderBy(s => s.Arginina);
                    break;
                case "Arginina_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Arginina);
                    break;
                default:
                    Bsort = Bsort.OrderBy(s => s.Cena);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Bsort.ToPagedList(pageNumber, pageSize));

        }


        // GET: Trzoda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrzodaModels trzodaModels = db.TrzodaProducts.Find(id);
            if (trzodaModels == null)
            {
                return HttpNotFound();
            }
            return View(trzodaModels);
        }

        // GET: Trzoda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trzoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Tluszcze,Wapn,Fosfor,Sod,Magnez,Lizyna,Metionina,Treonina,Arginina")] TrzodaModels trzodaModels)
        {
            if (ModelState.IsValid)
            {
                db.TrzodaProducts.Add(trzodaModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trzodaModels);
        }

        // GET: Trzoda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrzodaModels trzodaModels = db.TrzodaProducts.Find(id);
            if (trzodaModels == null)
            {
                return HttpNotFound();
            }
            return View(trzodaModels);
        }

        // POST: Trzoda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Tluszcze,Wapn,Fosfor,Sod,Magnez,Lizyna,Metionina,Treonina,Arginina")] TrzodaModels trzodaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trzodaModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trzodaModels);
        }

        // GET: Trzoda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrzodaModels trzodaModels = db.TrzodaProducts.Find(id);
            if (trzodaModels == null)
            {
                return HttpNotFound();
            }
            return View(trzodaModels);
        }

        // POST: Trzoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrzodaModels trzodaModels = db.TrzodaProducts.Find(id);
            db.TrzodaProducts.Remove(trzodaModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
