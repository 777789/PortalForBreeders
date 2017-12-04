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
    public class GesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ges
        public ActionResult Index()
        {
            return View(db.GesProducts.ToList());
        }

        // GET: Ges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GesModels gesModels = db.GesProducts.Find(id);
            if (gesModels == null)
            {
                return HttpNotFound();
            }
            return View(gesModels);
        }

        // GET: Ges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] GesModels gesModels)
        {
            if (ModelState.IsValid)
            {
                db.GesProducts.Add(gesModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gesModels);
        }

        // GET: Ges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GesModels gesModels = db.GesProducts.Find(id);
            if (gesModels == null)
            {
                return HttpNotFound();
            }
            return View(gesModels);
        }

        // POST: Ges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] GesModels gesModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gesModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gesModels);
        }

        // GET: Ges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GesModels gesModels = db.GesProducts.Find(id);
            if (gesModels == null)
            {
                return HttpNotFound();
            }
            return View(gesModels);
        }

        // POST: Ges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GesModels gesModels = db.GesProducts.Find(id);
            db.GesProducts.Remove(gesModels);
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
