using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;
using System.Threading.Tasks;

namespace EndToEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Porady()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Informacje()
        {
            ViewBag.Message = "";
            return View();
        }
        public ActionResult Producenci()
        {
            ViewBag.Message = "";
            return View();
        }
    }
}