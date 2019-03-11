using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Concrete
{
    public class UpdateTask
    {
        private TDList list;
        private List<string> Fields;
        int Id = 0; 
        public UpdateTask(List<string> _Fields)
        {
            list = new TDList();
            Fields = _Fields;
            Id = Int32.Parse(Fields[0]);
        }
        public void Edit()
        {
            var task = list.Tasks.Where(t => t.Id == Id).FirstOrDefault();
            task.Name = Fields[1];
            task.Objective = Fields[2];
            task.IdPriority = Int32.Parse(Fields[3]);
            task.IdCategory = Int32.Parse(Fields[4]);
            list.SaveChanges();
        }
        public Task GetTask()
        {
            return list.Tasks.Where(t => t.Id == Id).FirstOrDefault();
        }
    }
}