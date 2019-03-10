using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace ToDoList.Concrete
{
    public class ToDoCreateTask
    {
        public void Record(HttpRequestBase Request, ref AnalyzeTaskView AT)
        {
            using (TDList list = new TDList())
            {
                HttpCookie cookie = Request.Cookies["UserId"];
                Task task = new Task
                {
                    Name = AT.Name,
                    Objective = AT.Objective,
                    StartDate = AT.StartDate,
                    EndDate = AT.EndDate,
                    IdAccount = int.Parse(cookie.Value),
                    IdCategory = AT.selectCategoryItems,
                    IdPriority = AT.selectPriorityItems,
                };
                list.Tasks.Add(task);
                list.SaveChanges();
            }
        }
    }
}