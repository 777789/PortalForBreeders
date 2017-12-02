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
    public class BydloController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bydlo
        public ActionResult Index()
        {
            return View(db.BydloProducts.ToList());
        }

        // GET: Bydlo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BydloModels bydloModels = db.BydloProducts.Find(id);
            if (bydloModels == null)
            {
                return HttpNotFound();
            }
            return View(bydloModels);
        }

        // GET: Bydlo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bydlo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Wiek,Typ,Pasza,Producent,Cena,Bialko,Energia,Oleje_I_Tluszcze,Wapn,Fosfor,Sod")] BydloModels bydloModels)
        {
            if (ModelState.IsValid)
            {
                db.BydloProducts.Add(bydloModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bydloModels);
        }

        // GET: Bydlo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BydloModels bydloModels = db.BydloProducts.Find(id);
            if (bydloModels == null)
            {
                return HttpNotFound();
            }
            return View(bydloModels);
        }

        // POST: Bydlo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Wiek,Typ,Pasza,Producent,Cena,Bialko,Energia,Oleje_I_Tluszcze,Wapn,Fosfor,Sod")] BydloModels bydloModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bydloModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bydloModels);
        }

        // GET: Bydlo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BydloModels bydloModels = db.BydloProducts.Find(id);
            if (bydloModels == null)
            {
                return HttpNotFound();
            }
            return View(bydloModels);
        }

        // POST: Bydlo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BydloModels bydloModels = db.BydloProducts.Find(id);
            db.BydloProducts.Remove(bydloModels);
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
