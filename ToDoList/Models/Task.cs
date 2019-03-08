namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Objective { get; set; }

        [Required]
        [StringLength(20)]
        public string StartDate { get; set; }

        [Required]
        [StringLength(20)]
        public string EndDate { get; set; }

        public int IdAccount { get; set; }

        public int IdCategory { get; set; }

        public int IdPriority { get; set; }

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }

        public virtual Priority Priority { get; set; }
    }
}
