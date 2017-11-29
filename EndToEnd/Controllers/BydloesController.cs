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
    public class BydloesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bydloes
        public ActionResult Index()
        {
            return View(db.BydloProducts.ToList());
        }

        // GET: Bydloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.BydloProducts.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            return View(bydlo);
        }

        // GET: Bydloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bydloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Bialko_ogolne,Energia,Oleje_I_tluszcze,wapn,fosfor,sod,witamina_a,witamina_d3,witamina_c,witamina_e")] Bydlo bydlo)
        {
            if (ModelState.IsValid)
            {
                db.BydloProducts.Add(bydlo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bydlo);
        }

        // GET: Bydloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.BydloProducts.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            return View(bydlo);
        }

        // POST: Bydloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Bialko_ogolne,Energia,Oleje_I_tluszcze,wapn,fosfor,sod,witamina_a,witamina_d3,witamina_c,witamina_e")] Bydlo bydlo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bydlo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bydlo);
        }

        // GET: Bydloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.BydloProducts.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            return View(bydlo);
        }

        // POST: Bydloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bydlo bydlo = db.BydloProducts.Find(id);
            db.BydloProducts.Remove(bydlo);
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
