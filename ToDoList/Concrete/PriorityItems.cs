using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Concrete
{
    public class PriorityItems
    {
        public List<Priority> Priorities()
        {
            using (TDList data = new TDList())
            {
                return data.Priorities.ToList();
            }
        }
    }
}