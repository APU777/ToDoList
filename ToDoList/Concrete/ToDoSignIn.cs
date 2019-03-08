using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Concrete.Crypto;
using ToDoList.Models;

namespace ToDoList.Concrete
{
    public class ToDoSignIn
    {
        TDList list = new TDList();
        AccountSignIn ASI;
        string password;
        public ToDoSignIn(AccountSignIn _asi)
        {
            ASI = _asi;
            password = CryptoProvider.GetMD5Hash(ASI.Password);
        }
        public bool Login(AccountSignIn ASI)
        {
            return list.Accounts.Where
                        (
                            lp => lp.Login.Equals(ASI.Login) && lp.Password.Equals(password)
                        ).Any();
        }
        public int UserId(AccountSignIn ASI)
        {
            return list.Accounts.SingleOrDefault(lp => lp.Login.Equals(ASI.Login) && lp.Password.Equals(password)).Id;
        }
    }
}