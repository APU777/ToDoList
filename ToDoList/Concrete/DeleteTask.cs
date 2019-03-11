using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Concrete
{
    public class DeleteTask
    {
        public void RemoveTask(int id)
        {
            using (TDList list = new TDList())
            {
                var removeTask = list.Tasks.SingleOrDefault(t => t.Id == id);
                list.Tasks.Remove(removeTask);
                list.SaveChanges();
            }
        }
    }
}