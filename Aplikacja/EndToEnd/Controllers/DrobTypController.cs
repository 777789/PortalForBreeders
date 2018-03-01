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
    public class DrobTypController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DrobTyp
        public ActionResult Index()
        {
            return View();
        } 
    }
}
