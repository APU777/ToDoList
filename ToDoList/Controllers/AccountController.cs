using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using ToDoList.Concrete;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult ToDo()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult CreateTask(AnalyzeTaskView task)
        {
            if (ModelState.IsValid)
                return RedirectToAction("ToDo");
            else
            {
                PriorityItems priorityItems = new PriorityItems();
                CategoryItems categoryItems = new CategoryItems();
                SelectList listPriorityItems = new SelectList(priorityItems.Priorities(), "Id", "Name");
                SelectList listCategoryItems = new SelectList(categoryItems.Categories(), "Id", "Name");
                return View(new AccountTask
                {
                    Name = task.Name,
                    Objective = task.Objective,
                    EndDate = task.EndDate,
                    StartDate = task.StartDate,
                    selectCategoryItems = listCategoryItems,
                    selectPriorityItems = listPriorityItems
                });
            }
        }

        public ActionResult CreateTask()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult TaskPriority()
        {
            PriorityItems priorityItems = new PriorityItems();
            SelectList listItems = new SelectList(priorityItems.Priorities(), "Id", "Name");
            return PartialView("_TasksPriority", new AccountTask { selectPriorityItems = listItems });
        }

        [ChildActionOnly]
        public ActionResult TaskCategory()
        {
            CategoryItems categoryItems = new CategoryItems();
            SelectList listItems = new SelectList(categoryItems.Categories(), "Id", "Name");
            return PartialView("_TasksCategory", new AccountTask { selectCategoryItems = listItems });
        }
    }
}