using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Concrete;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie cookie = Response.Cookies["UserId"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            cookie = Response.Cookies["UserSign"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountSignIn account)
        {
            if (ModelState.IsValid)
            {
                ToDoSignIn TDSI = new ToDoSignIn(account);
                if (!TDSI.Login(account))
                {
                    ModelState.AddModelError("", "Password or Login is invalid ! ! !");
                    return View(account);
                }
                Cookie cookie = new Cookie();
                cookie.UserCookie(Response, account.Login + account.Password, TDSI.UserId(account));
                return RedirectToAction("ToDo", "Account");
            }
            return View(account);
        }

        [HttpPost]
        public ActionResult SignUp(AccountSignUp account)
        {
            if (ModelState.IsValid)
            {
                ToDoSignUp TDSU = new ToDoSignUp();
                TDSU.Registration(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public ActionResult SignUp()
        {
            HttpCookie cookie = Response.Cookies["UserId"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            cookie = Response.Cookies["UserSign"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return View();
        }
       
        
    }
}