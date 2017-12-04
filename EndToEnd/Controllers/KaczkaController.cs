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
    public class KaczkaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kaczka
        public ActionResult Index()
        {
            return View(db.KaczkaProducts.ToList());
        }

        // GET: Kaczka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KaczkaModels kaczkaModels = db.KaczkaProducts.Find(id);
            if (kaczkaModels == null)
            {
                return HttpNotFound();
            }
            return View(kaczkaModels);
        }

        // GET: Kaczka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kaczka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] KaczkaModels kaczkaModels)
        {
            if (ModelState.IsValid)
            {
                db.KaczkaProducts.Add(kaczkaModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaczkaModels);
        }

        // GET: Kaczka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KaczkaModels kaczkaModels = db.KaczkaProducts.Find(id);
            if (kaczkaModels == null)
            {
                return HttpNotFound();
            }
            return View(kaczkaModels);
        }

        // POST: Kaczka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] KaczkaModels kaczkaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaczkaModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaczkaModels);
        }

        // GET: Kaczka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KaczkaModels kaczkaModels = db.KaczkaProducts.Find(id);
            if (kaczkaModels == null)
            {
                return HttpNotFound();
            }
            return View(kaczkaModels);
        }

        // POST: Kaczka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KaczkaModels kaczkaModels = db.KaczkaProducts.Find(id);
            db.KaczkaProducts.Remove(kaczkaModels);
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
