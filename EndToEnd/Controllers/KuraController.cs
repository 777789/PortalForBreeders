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
    public class KuraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kura
        public ActionResult Index()
        {
            return View(db.DrobProducts.ToList());
        }

        // GET: Kura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuraModels kuraModels = db.DrobProducts.Find(id);
            if (kuraModels == null)
            {
                return HttpNotFound();
            }
            return View(kuraModels);
        }

        // GET: Kura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] KuraModels kuraModels)
        {
            if (ModelState.IsValid)
            {
                db.DrobProducts.Add(kuraModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kuraModels);
        }

        // GET: Kura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuraModels kuraModels = db.DrobProducts.Find(id);
            if (kuraModels == null)
            {
                return HttpNotFound();
            }
            return View(kuraModels);
        }

        // POST: Kura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] KuraModels kuraModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuraModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kuraModels);
        }

        // GET: Kura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KuraModels kuraModels = db.DrobProducts.Find(id);
            if (kuraModels == null)
            {
                return HttpNotFound();
            }
            return View(kuraModels);
        }

        // POST: Kura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KuraModels kuraModels = db.DrobProducts.Find(id);
            db.DrobProducts.Remove(kuraModels);
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
