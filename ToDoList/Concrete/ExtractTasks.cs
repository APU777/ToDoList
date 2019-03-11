using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Concrete
{
    public class ExtractTasks
    {
        public List<Task> GetTasks(int userId)
        {
            using (TDList list = new TDList())
            {
                return list.Tasks.Include("Priority").Include("Category").Where(i => i.IdAccount == userId).ToList();
            }
        }
    }
}