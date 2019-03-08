using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.Concrete
{
    public class ToDoSignUp
    {
        public void Registration(AccountSignUp ASU)
        {
            using (TDList list = new TDList())
            {
                Account account = new Account { Login = ASU.Login, Password = ASU.Password };
                list.Accounts.Add(account);
                list.SaveChanges();
            }
        }
    }
}