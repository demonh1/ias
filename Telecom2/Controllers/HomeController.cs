using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telecom2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Система учета заявок";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
