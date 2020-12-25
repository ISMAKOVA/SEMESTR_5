using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPIT_10.Models;

namespace BIPIT_10.Controllers
{
    public class EditController : Controller
    {
        galleryEntities gallery = new galleryEntities();

        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            var moving = gallery.Moving.Where(x => x.id == id).FirstOrDefault();
            List<SelectListItem> exhibits = new List<SelectListItem>();
            var exhibitsdb = gallery.Exhibits;
            foreach (var item in exhibitsdb)
            {
                exhibits.Add(new SelectListItem { Text = String.Format("{0} | {1} | {2}", item.exhibit, item.author, item.name), Value = item.id_exhibit.ToString() });
            }
            ViewBag.Exhibits = exhibits;
            ViewBag.Exhibit = gallery.Exhibits.Where(x => x.id_exhibit == moving.exhibit_fk).FirstOrDefault().name;
            List<SelectListItem> halls = new List<SelectListItem>();
            var hallsdb = gallery.Halls;
            foreach (var item in hallsdb)
            {
                halls.Add(new SelectListItem { Text = String.Format("{0} | {1} | {2}", item.hall_name, item.museum, item.city), Value = item.id_hall.ToString() });
            }
            ViewBag.Halls = halls;
            ViewBag.Hall = gallery.Halls.Where(x => x.id_hall == moving.halls_fk).FirstOrDefault().museum;

            ViewBag.start = moving.date_start;
            ViewBag.end = moving.date_end;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var e = Convert.ToInt32(form["exhibits"]);
            var h = Convert.ToInt32(form["halls"]);
            var start = Convert.ToDateTime(form["start"]);
            var end = Convert.ToDateTime(form["end"]);
            var id = Convert.ToInt32(form["id"]);

            var moving = gallery.Moving.Where(x => x.id == id).FirstOrDefault();
            moving.halls_fk = h;
            moving.exhibit_fk = e;
            moving.date_start = Convert.ToDateTime(start);
            moving.date_end = Convert.ToDateTime(end);
            gallery.SaveChanges();

            return Redirect(Url.Action("Index", "Home"));
        }
        public ActionResult Exhibit(int id)
        {
            ViewBag.Message = "Экспонаты";
            var exhibit = gallery.Exhibits.Where(x => x.id_exhibit == id).FirstOrDefault();
            ViewBag.exhibit = exhibit.exhibit;
            ViewBag.author = exhibit.author;
            ViewBag.material = exhibit.material;
            ViewBag.name = exhibit.name;
            ViewBag.year = exhibit.year;
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Exhibit(FormCollection form)
        {
            ViewBag.Message = "Экспонаты";
            var id = Convert.ToInt32(form["id"]);
            var exhibit = form["exhibit"];
            var author = form["author"];
            var name = form["name"];
            var material = form["material"];
            var year = form["year"];

            var e = gallery.Exhibits.Where(x => x.id_exhibit == id).FirstOrDefault();
            e.exhibit = exhibit;
            e.author = author;
            e.name = name;
            e.material = material;
            e.year = year;
            gallery.SaveChanges();

            return Redirect(Url.Action("Exhibit", "Home"));
        }

        public ActionResult Hall(int id)
        {
            ViewBag.Message = "Залы";
            var hall = gallery.Halls.Where(x => x.id_hall == id).FirstOrDefault();
            ViewBag.Id = id;
            ViewBag.hall_name = hall.hall_name;
            ViewBag.floor = hall.floor;
            ViewBag.museum = hall.museum;
            ViewBag.city = hall.city;

            return View();
        }
        [HttpPost]
        public ActionResult Hall(FormCollection form)
        {
            var h_n = form["hall_name"];
            var f = form["floor"];
            var m = form["museum"];
            var c = form["city"];
            var id = Convert.ToInt32(form["id"]);
            var hall = gallery.Halls.Where(x => x.id_hall == id).FirstOrDefault();
            hall.hall_name = h_n;
            hall.floor = f;
            hall.museum = m;
            hall.city = c;
            gallery.SaveChanges();
            return Redirect(Url.Action("Hall", "Home"));
        }
    }
}