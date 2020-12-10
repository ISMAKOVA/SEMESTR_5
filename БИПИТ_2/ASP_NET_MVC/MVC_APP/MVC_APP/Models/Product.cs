using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class Product
    {
        // ID продукта
        public int Id { get; set; }
        // название продукта
        public string Name { get; set; }
        // автор продукта
        public string Country { get; set; }
        // продукта
        public int Price { get; set; }
    }
}