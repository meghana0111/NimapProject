using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ApplicationDbContext dataServe = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterUser()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterUser(User userData)
        {

            if (ModelState.IsValid)
            {
                dataServe.users.Add(userData);
                dataServe.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginPage loginCredential)
        {

            var user = dataServe.users.FirstOrDefault(x => x.UserName == loginCredential.Username);
            if (user != null && loginCredential.Password == user.Password)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Categories");
            }

            ModelState.AddModelError("", "Invalid Username and Password");
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}