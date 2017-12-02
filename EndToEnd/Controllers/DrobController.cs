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
    public class DrobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drob
        public ActionResult Index()
        {
            return View(db.DrobProducts.ToList());
        }

        // GET: Drob/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrobModels drobModels = db.DrobProducts.Find(id);
            if (drobModels == null)
            {
                return HttpNotFound();
            }
            return View(drobModels);
        }

        // GET: Drob/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje_i_tluszcze,Wlokno_surowe,Popiol_surowy,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] DrobModels drobModels)
        {
            if (ModelState.IsValid)
            {
                db.DrobProducts.Add(drobModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drobModels);
        }

        // GET: Drob/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrobModels drobModels = db.DrobProducts.Find(id);
            if (drobModels == null)
            {
                return HttpNotFound();
            }
            return View(drobModels);
        }

        // POST: Drob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje_i_tluszcze,Wlokno_surowe,Popiol_surowy,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] DrobModels drobModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drobModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drobModels);
        }

        // GET: Drob/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrobModels drobModels = db.DrobProducts.Find(id);
            if (drobModels == null)
            {
                return HttpNotFound();
            }
            return View(drobModels);
        }

        // POST: Drob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrobModels drobModels = db.DrobProducts.Find(id);
            db.DrobProducts.Remove(drobModels);
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
