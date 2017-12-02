using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;

namespace EndToEnd.Controllers
{
    public class TrzodaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trzoda
        public ActionResult Index()
        {
            return View(db.TrzodaProducts.ToList());
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
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Tluszcze,Wlokno_surowe,Popiol_surowy,Wapn,Fosfor,Sod,Magnez,Lizyna,Metionina,Treonina,Arginina")] TrzodaModels trzodaModels)
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
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Tluszcze,Wlokno_surowe,Popiol_surowy,Wapn,Fosfor,Sod,Magnez,Lizyna,Metionina,Treonina,Arginina")] TrzodaModels trzodaModels)
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
