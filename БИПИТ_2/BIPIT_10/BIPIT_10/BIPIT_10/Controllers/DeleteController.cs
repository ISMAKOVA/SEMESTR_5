using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT_10.Models;

namespace BIPIT_10.Controllers
{
    public class DeleteController : Controller
    {
        galleryEntities gallery = new galleryEntities();

        public ActionResult Index(int id)
        {
            Moving Moving = new Moving { id = id };

            gallery.Moving.Attach(Moving);
            gallery.Moving.Remove(Moving);
            gallery.SaveChanges();
            return Redirect(Url.Action("Index", "Home"));
        }

        public ActionResult Exhibit(int id)
        {
            ViewBag.Message = "Экспонаты";
            Exhibits exhibits = new Exhibits { id_exhibit = id };

            gallery.Exhibits.Attach(exhibits);
            gallery.Exhibits.Remove(exhibits);
            gallery.SaveChanges();
            return Redirect(Url.Action("Exhibit", "Home"));
        }

        public ActionResult Hall(int id)
        {
            ViewBag.Message = "Залы";
            Halls halls = new Halls { id_hall = id };

            gallery.Halls.Attach(halls);
            gallery.Halls.Remove(halls);
            gallery.SaveChanges();
            return Redirect(Url.Action("Hall", "Home"));
        }
    }
}