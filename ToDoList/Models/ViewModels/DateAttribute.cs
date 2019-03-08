using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ToDoList.Models.ViewModels
{
    public class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int sd = 0, ed = 0;
            string StartDate = (validationContext.ObjectInstance as AnalyzeTaskView).StartDate;
            string EndDate = (validationContext.ObjectInstance as AnalyzeTaskView).EndDate;
            int.TryParse(Regex.Replace(StartDate??"1", "[^0-9, ]", ""), out sd);
            int.TryParse(Regex.Replace(EndDate??"1", "[^0-9, ]", ""), out ed);
            int DateValue = sd - ed;
            ValidationResult result = DateValue > 0 ? new ValidationResult("Wrong date") : null;
            return result;
        }
    }
}