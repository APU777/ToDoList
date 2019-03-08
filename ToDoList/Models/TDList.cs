namespace ToDoList
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TDList : DbContext
    {
        public TDList()
            : base("name=TDList")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.IdAccount);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory);

            modelBuilder.Entity<Priority>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Priority)
                .HasForeignKey(e => e.IdPriority);
        }
    }
}
