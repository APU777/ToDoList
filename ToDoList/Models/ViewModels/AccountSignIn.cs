using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class AccountSignIn
    {
        [Required(ErrorMessage = "There is no login")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Login should be [8 -100] symbols.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "There is no password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password should be [5 -100] symbols.")]
        public string Password { get; set; }
    }
}