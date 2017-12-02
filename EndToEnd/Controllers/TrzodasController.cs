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
    public class TrzodasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trzodas
        public ActionResult Index()
        {
            return View(db.TrzodaProducts.ToList());
        }

        // GET: Trzodas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trzoda trzoda = db.TrzodaProducts.Find(id);
            if (trzoda == null)
            {
                return HttpNotFound();
            }
            return View(trzoda);
        }

        // GET: Trzodas/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trzodas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,Bialko_ogolne,Energia,Oleje_i_tluszcze,wlokno_surowe,popiol_surowy,wapn,fosfor,sod,magnez,lizyna,metionina,treonina,arginina,witamina_a,witamina_d3,witamina_e")] Trzoda trzoda)
        {
            if (ModelState.IsValid)
            {
                db.TrzodaProducts.Add(trzoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trzoda);
        }

        // GET: Trzodas/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trzoda trzoda = db.TrzodaProducts.Find(id);
            if (trzoda == null)
            {
                return HttpNotFound();
            }
            return View(trzoda);
        }

        // POST: Trzodas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,Bialko_ogolne,Energia,Oleje_i_tluszcze,wlokno_surowe,popiol_surowy,wapn,fosfor,sod,magnez,lizyna,metionina,treonina,arginina,witamina_a,witamina_d3,witamina_e")] Trzoda trzoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trzoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trzoda);
        }

        // GET: Trzodas/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trzoda trzoda = db.TrzodaProducts.Find(id);
            if (trzoda == null)
            {
                return HttpNotFound();
            }
            return View(trzoda);
        }

        // POST: Trzodas/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trzoda trzoda = db.TrzodaProducts.Find(id);
            db.TrzodaProducts.Remove(trzoda);
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
