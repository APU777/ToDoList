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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountSignIn account)
        {
            if (ModelState.IsValid)
            {
                ToDoSignIn TDSI = new ToDoSignIn();

                if (!TDSI.Login(account))
                {
                    ModelState.AddModelError("", "Password or Login is invalid ! ! !");
                    return View(account);
                }
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
            return View();
        }
       
        
    }
}