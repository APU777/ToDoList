using System.Data.Entity;

namespace ToDoList
{
    internal class SetDataPC<T> : DropCreateDatabaseIfModelChanges<TDList>
    {
        protected override void Seed(TDList context)
        {
            context.Priorities.Add(new Priority { Name = "Low" });
            context.Priorities.Add(new Priority { Name = "Normal" });
            context.Priorities.Add(new Priority { Name = "High" });

            context.Categories.Add(new Category { Name = "Study" });
            context.Categories.Add(new Category { Name = "Work" });
            context.Categories.Add(new Category { Name = "Home" });
            context.Categories.Add(new Category { Name = "Hobby" });
            context.Categories.Add(new Category { Name = "Holiday" });
            context.Categories.Add(new Category { Name = "Weekend" });
            context.Categories.Add(new Category { Name = "Free Time" });

            context.SaveChanges();
        }
    }
}