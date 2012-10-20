using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewsLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Url = "/Images/transsiberian.jpg";
            ViewBag.Alt = "Trans-Siberian Express";
            ViewBag.Id = 1;

            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
