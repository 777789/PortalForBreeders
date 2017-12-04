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
    public class IndykController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Indyk
        public ActionResult Index()
        {
            return View(db.IndykProducts.ToList());
        }

        // GET: Indyk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndykModels indykModels = db.IndykProducts.Find(id);
            if (indykModels == null)
            {
                return HttpNotFound();
            }
            return View(indykModels);
        }

        // GET: Indyk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indyk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] IndykModels indykModels)
        {
            if (ModelState.IsValid)
            {
                db.IndykProducts.Add(indykModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indykModels);
        }

        // GET: Indyk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndykModels indykModels = db.IndykProducts.Find(id);
            if (indykModels == null)
            {
                return HttpNotFound();
            }
            return View(indykModels);
        }

        // POST: Indyk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wiek,Pasza,Producent,Cena,Bialko,Energia,Oleje,Wapn,Fosfor,Sod,Lizyna,Metionina,Treonina")] IndykModels indykModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indykModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indykModels);
        }

        // GET: Indyk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndykModels indykModels = db.IndykProducts.Find(id);
            if (indykModels == null)
            {
                return HttpNotFound();
            }
            return View(indykModels);
        }

        // POST: Indyk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndykModels indykModels = db.IndykProducts.Find(id);
            db.IndykProducts.Remove(indykModels);
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
