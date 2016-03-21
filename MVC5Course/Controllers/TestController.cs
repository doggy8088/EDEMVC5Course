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
        FabricsEntities db = new FabricsEntities();

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

        public ActionResult ReadProduct(bool? Active)
        {
            var data = db.Product.OrderByDescending(p => p.Price).AsQueryable();

            data = data
                .Where(p => p.ProductId > 1550);

            if (Active.HasValue)
            {
                data = data.Where(p => p.Active == Active);
            }

            return View(data);
        }

        public ActionResult OneProduct(int id)
        {
            var data = db.Product.Find(id);
            //var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult UpdateProduct(int id)
        {
            var one = db.Product.FirstOrDefault(p => p.ProductId == id);

            if (one == null)
            {
                return HttpNotFound();
            }

            one.Price = one.Price * 2;

            db.SaveChanges();

            return RedirectToAction("ReadProduct");
        }

        public ActionResult DeleteProduct(int id)
        {
            var one = db.Product.Include("OrderLine").FirstOrDefault(p => p.ProductId == id);

            //foreach (var item in db.OrderLine.Where(p => p.ProductId == id).ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            //foreach (var item in one.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            db.Database.ExecuteSqlCommand(@"DELETE FROM dbo.OrderLine WHERE ProductId=@p0", id);
            //db.OrderLine.RemoveRange(one.OrderLine);

            db.Product.Remove(one);

            db.SaveChanges();

            return RedirectToAction("ReadProduct");
        }

        public ActionResult ProductView()
        {
            var data = db.Database.SqlQuery<ProductViewModel>(
                @"SELECT * FROM dbo.Product WHERE Active=@p0 AND ProductName like @p1", true, "%Yellow%");

            return View(data);
        }
    }
}