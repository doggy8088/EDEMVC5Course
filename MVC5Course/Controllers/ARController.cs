using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView("Index");
        }

        public ActionResult FileTest(int? dl)
        {
            if (dl.HasValue)
            {
                return File(Server.MapPath("~/Content/google.jpg"), "image/jpeg", "google.jpg");
            }
            else
            {
                return File(Server.MapPath("~/Content/google.jpg"), "image/jpeg");
            }
        }

        public ActionResult JsonTest(int id)
        {
            repoProduct.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var product = repoProduct.Find(id);

            return Json(product, JsonRequestBehavior.AllowGet);

        }
    }
}