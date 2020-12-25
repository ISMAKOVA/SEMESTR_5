using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT_10.Models;

namespace BIPIT_9.Controllers
{
    public class HomeController : Controller
    {
        galleryEntities gallery = new galleryEntities();
        public ActionResult Index()
        {
            return View(gallery.Moving.ToList());
        }

        public ActionResult Exhibit()
        {
            ViewBag.Message = "Экспонаты";
            
            return View(gallery.Exhibits.ToList());
        }

        public ActionResult Hall()
        {
            ViewBag.Message = "Залы";

            return View(gallery.Halls.ToList());
        }
    }
}