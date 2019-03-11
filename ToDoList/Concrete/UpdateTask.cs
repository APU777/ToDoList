using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Concrete
{
    public class UpdateTask
    {
        public void Edit(List<string> Fields)
        {
            using (TDList list = new TDList())
            {
                Task task = list.Tasks.SingleOrDefault(t => t.Name.Equals(Fields[0]) && t.Objective.Equals(Fields[1]));
                task.Name = Fields[2];
                task.Objective = Fields[3];
                task.IdPriority = Int32.Parse(Fields[4]);
                task.IdCategory = Int32.Parse(Fields[5]);
                list.SaveChanges();
            }
        }
    }
}