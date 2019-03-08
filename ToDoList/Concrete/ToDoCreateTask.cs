using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.Concrete
{
    public class ToDoCreateTask
    {
        public void Record(AccountTask AT)
        {
            using (TDList list = new TDList())
            {
                Task task = new Task { Name = AT.Name, Objective = AT.Objective, }; 
            }
        }
    }
}