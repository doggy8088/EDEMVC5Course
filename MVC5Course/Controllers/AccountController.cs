using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel data)
        {
            if (CheckLogin(data))
            {
                FormsAuthentication.RedirectFromLoginPage(data.Email, false);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        private bool CheckLogin(LoginViewModel data)
        {
            return (data.Email == "doggy.huang@gmail.com" && data.Password == "123");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel data)
        {
            if (ModelState.IsValid)
            {
                // TODO

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel data)
        {
            if (ModelState.IsValid)
            {
                // TODO

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}