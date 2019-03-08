using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Concrete
{
    public class CategoryItems
    {
        public List<Category> Categories()
        {
            using (TDList data = new TDList())
            {
                return data.Categories.ToList();
            }
        }
    }
}