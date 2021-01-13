using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT_11.Models;
namespace BIPIT_11.Controllers
{
    public class HomeController : Controller
    {
        galleryEntities gallery = new galleryEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exhibit()
        {
            ViewBag.Message = "Экспонаты";

            return View();
        }

        public ActionResult Hall()
        {
            ViewBag.Message = "Залы";

            return View();
        }
    }
}
