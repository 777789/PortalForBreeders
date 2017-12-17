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

namespace EndToEnd.Controllers
{
    public class BydloController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Bydlo
        
        public ActionResult Index(string sortowanie, BydloModels Model)
        {
            var sortowaniebydlo = from i in db.BydloProducts
                                  select i;
            if (Model != null)
            {
                sortowaniebydlo = from i in db.BydloProducts
                                  where i.Wiek.Equals(Model.Wiek)
                                  select i;
            }
           
            ViewBag.SortByCena = sortowanie == "Cena_Malejaco" ? "Cena_Rosnaco" : "Cena_Malejaco";
            ViewBag.SortByBialko = sortowanie == "Bialko_Malejaco" ? "Bialko_Rosnaco" : "Bialko_Malejaco";
            ViewBag.SortByEnergia = sortowanie == "Energia_Malejaco" ? "Energia_Rosnaco" : "Energia_Malejaco";

            var produktyDlaBydla = from i in db.BydloProducts
                                   select i;
            switch (sortowanie)
            {
                case "Cena_Malejaco":
                    produktyDlaBydla = produktyDlaBydla.OrderByDescending(s => s.Cena);
                    break;
                case "Cena_Rosnaco":
                    produktyDlaBydla = produktyDlaBydla.OrderBy(s => s.Cena);
                    break;
                case "Bialko_Malejaco":
                    produktyDlaBydla = produktyDlaBydla.OrderByDescending(s => s.Bialko);
                    break;
                case "Bialko_Rosnaco":
                    produktyDlaBydla = produktyDlaBydla.OrderBy(s => s.Bialko);
                    break;
                case "Energia_Malejaco":
                    produktyDlaBydla = produktyDlaBydla.OrderByDescending(s => s.Energia);
                    break;
                case "Energia_Rosnaco":
                    produktyDlaBydla = produktyDlaBydla.OrderBy(s => s.Energia);
                    break;
                default:
                    produktyDlaBydla = produktyDlaBydla.OrderBy(s => s.Cena);
                    break;
            }

            if (ModelState.IsValid)
            {
                if (Model.Wiek != null && Model.Typ != null)
                {
                    produktyDlaBydla = from i in db.BydloProducts
                                       where i.Wiek.Equals(Model.Wiek)
                                             && i.Typ.Equals(Model.Typ)
                                       select i;
                }
                else if (Model.Wiek != null)
                {
                    produktyDlaBydla = from i in db.BydloProducts
                                       where i.Wiek.Equals(Model.Wiek)
                                       select i;
                }
                else if (Model.Typ != null)
                {
                    produktyDlaBydla = from i in db.BydloProducts
                                       where i.Typ.Equals(Model.Typ)
                                       select i;
                }
            }
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
