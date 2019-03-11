using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models.ViewModels
{
    public class CheckLoginDBAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (TDList list = new TDList())
            {
                string Login = (validationContext.ObjectInstance as AccountSignUp).Login;

                ValidationResult VR = list.Accounts.Where(
                                                a => a.Login.Equals(Login)
                                            ).Any() == true ? new ValidationResult("Login is already exist.") : null;
                return VR;
            }
        }
    }
}