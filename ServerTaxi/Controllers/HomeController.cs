using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerTaxi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Auth()
        {
            ViewBag.Title = "Auth Page";
            return View();
        }
        public ActionResult DriverAuth()
        {
            ViewBag.Title = "Auth Page";
            return View();
        }
        public ActionResult ActiveOrders()
        {
            ViewBag.Title = "Orders";
            return View();
        }
        public ActionResult DriverOrders()
        {
            ViewBag.Title = "You Orders";
            return View();
        }
        public ActionResult NewOrder()
        {
            ViewBag.Title = "New order";
            return View();
        }
        public ActionResult Orders()
        {
            ViewBag.Title = "Auth Page";
            return View();
        }
    }
}
