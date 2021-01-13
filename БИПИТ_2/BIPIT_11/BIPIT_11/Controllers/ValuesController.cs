using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIPIT_11.Models;
using System.Data;
using System.Data.Entity;

namespace BIPIT_11.Controllers
{
    public class ValuesController : ApiController
    {

        galleryEntities gallery = new galleryEntities();
        ValuesController()
        {
            gallery.Configuration.ProxyCreationEnabled = false;
        }

        [Route("~/api/GetExhibits")]
        [HttpGet]
        public IEnumerable<Exhibits> GetExhibits()
        {
            return gallery.Exhibits;
        }

        [Route("~/api/GetHalls")]
        [HttpGet]
        public IEnumerable<Halls> GetHalls()
        {
            return gallery.Halls;
        }

        [Route("~/api/GetMovings")]
        [HttpGet]
        public IEnumerable<Moving> GetMovings()
        {
            return gallery.Moving;
        }


        [Route("~/api/CreatetExhibit")]
        [HttpPost]
        public void CreatetExhibit([FromBody] Exhibits exhibit)
        {
            gallery.Exhibits.Add(exhibit);
            gallery.SaveChanges();
        }

        [Route("~/api/CreatetHall")]
        [HttpPost]
        public void CreatetHall([FromBody] Halls hall)
        {
            gallery.Halls.Add(hall);
            gallery.SaveChanges();
        }

        [Route("~/api/CreatetMoving")]
        [HttpPost]
        public void CreatetMoving([FromBody] Moving moving)
        {
            gallery.Moving.Add(moving);
            gallery.SaveChanges();
        }

        [Route("~/api/DeleteExhibit")]
        [HttpDelete]
        public void DeleteExhibit(int id)
        {
            Exhibits exhibits = new Exhibits { id_exhibit = id };

            gallery.Exhibits.Attach(exhibits);
            gallery.Exhibits.Remove(exhibits);
            gallery.SaveChanges();
        }

        [Route("~/api/DeleteHall")]
        [HttpDelete]
        public void DeleteHall(int id)
        {
            Halls halls = new Halls { id_hall = id };

            gallery.Halls.Attach(halls);
            gallery.Halls.Remove(halls);
            gallery.SaveChanges();
        }

        [Route("~/api/DeleteMoving")]
        [HttpDelete]
        public void DeleteMoving(int id)
        {
            Moving Moving = new Moving { id = id };

            gallery.Moving.Attach(Moving);
            gallery.Moving.Remove(Moving);
            gallery.SaveChanges();
        }
    }
}
