using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;
using System.Web.UI;
using System.Web.UI.WebControls.Expressions;
using PagedList;

namespace EndToEnd.Controllers
{
    public class BydloController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Bydlo  
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CenaSortParm = String.IsNullOrEmpty(sortOrder) ? "Cena" : "";
            ViewBag.BialkoSortParm = sortOrder == "Bialko" ? "bialko_desc" : "Bialko";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Bsort = from s in db.BydloProducts
                select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                Bsort = db.BydloProducts.Where(s => s.Wiek.Contains(searchString));
              
            }

            switch (sortOrder)
            {
                case "Cena":
                    Bsort = Bsort.OrderByDescending(s => s.Cena);
                    break;
                case "Bialko":
                    Bsort = Bsort.OrderBy(s => s.Bialko);
                    break;
                case "bialko_desc":
                    Bsort = Bsort.OrderByDescending(s => s.Bialko);
                    break;
                default:
                    Bsort = Bsort.OrderBy(s => s.Cena);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Bsort.ToPagedList(pageNumber, pageSize));

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

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bydlo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
