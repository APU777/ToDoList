using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoList.Models
{
    public class AccountTask
    {
        [Required(ErrorMessage = "Name is empty.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Login should be [1 -100] symbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Objective is empty.")]
        public string Objective { get; set; }

        [Required(ErrorMessage = "Start date is empty.")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "End date is empty.")]
        public string EndDate { get; set; }
         
        public SelectList selectCategoryItems { get; set; }

        public SelectList selectPriorityItems { get; set; }
    }
}