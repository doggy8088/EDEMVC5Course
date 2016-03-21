using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EDE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EDE(EDEViewModel data)
        {
            return View(data);
        }

        public ActionResult CreateProduct()
        {
            var db = new FabricsEntities();

            var product = new Product()
            {
                ProductName = "Tercel",
                Active = true,
                Price = 1999,
                Stock = 5
            };

            db.Product.Add(product);
            db.SaveChanges();

            return View(product);
        }

    }
}