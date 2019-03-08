using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.Concrete
{
    public class ToDoSignIn
    {
        public bool Login (AccountSignIn ASI)
        {
            using (TDList list = new TDList())
            {
                return list.Accounts.Where(lp => lp.Login.Equals(ASI.Login) && lp.Password.Equals(ASI.Password)).Any();
            }
        }
    }
}