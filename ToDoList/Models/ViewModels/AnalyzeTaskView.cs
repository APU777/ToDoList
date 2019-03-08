using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models.ViewModels
{
    public class AnalyzeTaskView
    {
        [Required(ErrorMessage = "Name is empty.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Login should be [1 -100] symbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Objective is empty.")]
        public string Objective { get; set; }

        [Required(ErrorMessage = "Start date is empty.")]
        [Date]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "End date is empty.")]
        public string EndDate { get; set; }

        public int selectCategoryItems { get; set; }

        public int selectPriorityItems { get; set; }
    }
}