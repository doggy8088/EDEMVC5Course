using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ProductRepository repoProduct 
            = RepositoryHelper.GetProductRepository();

        protected override void HandleUnknownAction(string actionName)
        {
            this.RedirectToAction("Index", "Home")
                .ExecuteResult(this.ControllerContext);
        }
    }
}