using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT_10.Models;

namespace BIPIT_10.Controllers
{
    public class CreateController : Controller
    {
        galleryEntities gallery = new galleryEntities();

        public ActionResult Index()
        {
            List<SelectListItem> exhibits = new List<SelectListItem>();
            var exhibitsdb =gallery.Exhibits;
            foreach (var item in exhibitsdb)
            {
                exhibits.Add(new SelectListItem { Text = String.Format("{0} | {1} | {2}", item.exhibit, item.author, item.name), Value = item.id_exhibit.ToString() });
            }
            ViewBag.Exhibits = exhibits;

            List<SelectListItem> halls = new List<SelectListItem>();
            var hallsdb = gallery.Halls;
            foreach (var item in hallsdb)
            {
                halls.Add(new SelectListItem { Text = String.Format("{0} | {1} | {2}", item.hall_name, item.museum, item.city), Value = item.id_hall.ToString() });
            }
            ViewBag.Halls = halls;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var e = Convert.ToInt32(form["exhibits"]);
            var h = Convert.ToInt32(form["halls"]);
            var start = Convert.ToDateTime(form["start"]);
            var end = Convert.ToDateTime(form["end"]);
            Moving moving = new Moving
            {
                exhibit_fk = e,
                halls_fk = h,
                date_start = start,
                date_end = end
            };
            gallery.Moving.Add(moving);
            gallery.SaveChanges();
            return Redirect(Url.Action("Index", "Home"));
        }
        public ActionResult Exhibit()
        {
            ViewBag.Message = "Добавить экспонат";
            return View();
        }
        [HttpPost]
        public ActionResult Exhibit(FormCollection form)
        {
            var exhibit = form["exhibit"];
            var author = form["author"];
            var name = form["name"];
            var material = form["material"];
            var year = form["year"];

            Exhibits exhibits = new Exhibits
            {
                exhibit = exhibit,
                author = author,
                name= name,
                material = material,
                year = year
            };
            gallery.Exhibits.Add(exhibits);
            gallery.SaveChanges();
            ViewBag.Message = "Экспонаты";

            return Redirect(Url.Action("Exhibit", "Home"));
        }

        public ActionResult Hall()
        {
            ViewBag.Message = "Залы";

            return View();
        }
        [HttpPost]
        public ActionResult Hall(FormCollection form)
        {
            var h_n = form["hall_name"];
            var f = form["floor"];
            var m = form["museum"];
            var c = form["city"];

            Halls halls = new Halls
            {
                hall_name = h_n,
                floor = f,
                museum = m,
                city = c
            };
            gallery.Halls.Add(halls);
            gallery.SaveChanges();
            ViewBag.Message = "Залы";

            return Redirect(Url.Action("Hall", "Home"));
        }



    }
}