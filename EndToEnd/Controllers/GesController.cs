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
            Ges ges = db.GesProducts.Find(id);
            if (ges == null)
            {
                return HttpNotFound();
            }
            return View(ges);
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
        public ActionResult Create([Bind(Include = "Id,Name,Bialko_ogolne,Energia,Oleje_i_tluszcze,wlokno_surowe,popiol_surowy,wapn,fosfor_przyswajalny,sod,lizyna,metionina,treonina,tryptofan,witamina_a,witamina_d3,witamina_e")] Ges ges)
        {
            if (ModelState.IsValid)
            {
                db.GesProducts.Add(ges);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ges);
        }

        // GET: Ges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ges ges = db.GesProducts.Find(id);
            if (ges == null)
            {
                return HttpNotFound();
            }
            return View(ges);
        }

        // POST: Ges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Bialko_ogolne,Energia,Oleje_i_tluszcze,wlokno_surowe,popiol_surowy,wapn,fosfor_przyswajalny,sod,lizyna,metionina,treonina,tryptofan,witamina_a,witamina_d3,witamina_e")] Ges ges)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ges).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ges);
        }

        // GET: Ges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ges ges = db.GesProducts.Find(id);
            if (ges == null)
            {
                return HttpNotFound();
            }
            return View(ges);
        }

        // POST: Ges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ges ges = db.GesProducts.Find(id);
            db.GesProducts.Remove(ges);
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
