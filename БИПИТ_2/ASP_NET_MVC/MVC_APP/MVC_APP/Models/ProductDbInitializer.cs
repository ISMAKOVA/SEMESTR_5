using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_APP.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "Тапки", Country = "Китай", Price = 520 });
            db.Products.Add(new Product { Name = "Ивановский платок", Country = "Россия", Price = 1080 });
            db.Products.Add(new Product { Name = "Косметика от BTS", Country = "Южная Корея", Price = 5050 });

            base.Seed(db);
        }

    }
}