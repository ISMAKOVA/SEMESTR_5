using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_APP.Models;


namespace ProductStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Product
            IEnumerable<Product> products = db.Products;
            // передаем все объекты в динамическое свойство Products в ViewBag
            ViewBag.Products = products;
            // возвращаем представление
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Рахмет, " + purchase.Person + ", за покупку!";
        }
    }
}