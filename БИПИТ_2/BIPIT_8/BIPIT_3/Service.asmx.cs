using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace BIPIT_8
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
       
        [WebMethod]
        public DataSet GetData(string date_start, string date_end)
        {
            DataSet dataSet = new DataSet();
            using (galleryEntities gallery = new galleryEntities())
            {
                var moving = gallery.Moving;

                var col = new List<string>() { "Id", "Экспонат", "Название", "Автор", "Музей", "Возраст работы", "Дата поступления" };
                DataTable table = new DataTable("Moving");

                foreach (var c in col)
                    table.Columns.Add(c);

                foreach (var m in moving)
                {
                    if(date_start=="" || date_end == "")
                    {
                        table.Rows.Add(
                           m.id,
                           m.Exhibits.exhibit,
                           m.Exhibits.name,
                           m.Exhibits.author,
                           m.Halls.museum,
                           DateTime.Now.Year - Convert.ToInt32(m.Exhibits.year),
                           m.date_start.ToShortDateString()
                           );
                    }
                    else
                    {
                        if (Convert.ToDateTime(date_start) <= m.date_start && m.date_start <= Convert.ToDateTime(date_end))
                        {
                            table.Rows.Add(
                                m.id,
                                m.Exhibits.exhibit,
                                m.Exhibits.name,
                                m.Exhibits.author,
                                m.Halls.museum,
                                DateTime.Now.Year - Convert.ToInt32(m.Exhibits.year),
                                m.date_start.ToShortDateString()
                                );
                        }
                    }
                }
                dataSet.Tables.Add(table);
            }
            return dataSet;
        }

        [WebMethod]
        public void NewRec(string exh_fk, string halls_fk,string date_start, string date_end)
        {
            using (galleryEntities gallery = new galleryEntities())
            {
                var moving = gallery.Moving;
                Moving movingToAdd = new Moving
                {
                    exhibit_fk = Convert.ToInt32(exh_fk),
                    halls_fk = Convert.ToInt32(halls_fk),
                    date_start = Convert.ToDateTime(date_start),
                    date_end = Convert.ToDateTime(date_end)
                };
                moving.Add(movingToAdd);
                gallery.SaveChanges();
            }
        }

        [WebMethod]
        public void DeleteRec(int id)
        {
            using (galleryEntities gallery = new galleryEntities())
            {
                var moving = gallery.Moving;
                Moving movingToDelete = gallery.Moving.Where(n => n.id == id).FirstOrDefault();
                if (movingToDelete != null)
                {
                    gallery.Moving.Remove(movingToDelete);
                    gallery.SaveChanges();
                }
            }
        }

        [WebMethod]
        public DataSet Show(string tableName)
        {
            DataSet dataSet = new DataSet();
            using (galleryEntities gallery = new galleryEntities())
            {
                if (tableName == "exhibits")
                {
                    var exhibits = gallery.Exhibits;
                    var col = new List<string>() { "Id", "Экспонат", "Автор", "Название", "Материалы", "Возраст работы"};
                    DataTable table = new DataTable("exhibits");
                    foreach (var c in col)
                        table.Columns.Add(c);

                    foreach(var e in exhibits)
                    {
                        table.Rows.Add(
                            e.id_exhibit,
                            e.exhibit,
                            e.author,
                            e.name,
                            e.material,
                            e.year
                            );
                    }
                    dataSet.Tables.Add(table);
                }
                else if(tableName == "halls")
                {
                    var halls = gallery.Halls;
                    var col = new List<string>() { "Id", "Название", "Этаж ", "Музей", "Город" };
                    DataTable table = new DataTable("halls");
                    foreach (var c in col)
                        table.Columns.Add(c);

                    foreach(var h in halls)
                    {
                        table.Rows.Add(
                            h.id_hall,
                            h.hall_name,
                            h.floor,
                            h.museum,
                            h.city
                            );
                    }
                    dataSet.Tables.Add(table);
                }
                
            }
            return dataSet;

        }


    }
}
