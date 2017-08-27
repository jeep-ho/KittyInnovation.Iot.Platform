using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KittyInnovation.Iot.Platform.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string userName,string ticket)
        {
            ViewBag.Ticket = ticket;
            ViewBag.UserName = userName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}