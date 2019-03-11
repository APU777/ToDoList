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
            HttpCookie httpCookie = Request.Cookies["UserSign"];
            if (httpCookie != null)
            {
                HttpCookie cookie = Request.Cookies["UserId"];
                ExtractTasks extractTasks = new ExtractTasks();
                IEnumerable<Task> tasks = extractTasks.GetTasks(Int32.Parse(cookie.Value));
                return View(tasks);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteTask(string _TaskId)
        {
            DeleteTask deleteTask = new DeleteTask();
            deleteTask.RemoveTask(Int32.Parse(_TaskId));
            return Json(_TaskId);
        }

        [HttpPost]
        public ActionResult CreateTask(AnalyzeTaskView task)
        {
            if (ModelState.IsValid)
            {
                ToDoCreateTask toDoCreateTask = new ToDoCreateTask();
                toDoCreateTask.Record(Request, ref task);
                return RedirectToAction("ToDo");
            }
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

        [HttpPost]
        public ActionResult EditTask (List<string> _Fields)
        {
            UpdateTask updateTask = new UpdateTask(_Fields);
            updateTask.Edit();
            var r = updateTask.GetTask();
            var Result = new
            {
                rName = r.Name,
                rObjective = r.Objective,
                rCategory = r.Category.Name,
                rPriority = r.Priority.Name
            };
            return Json(Result);//RedirectToAction("ToDo");
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            HttpCookie httpCookie = Request.Cookies["UserSign"];
            if (httpCookie != null)
                return View();
            return RedirectToAction("Index", "Home");
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