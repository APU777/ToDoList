using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Concrete.Crypto;

namespace ToDoList.Concrete
{
    public class Cookie
    {
        public void UserCookie(HttpResponseBase Response, string UserUniqueData, int UserId)
        {
            HttpCookie cookieSign = new HttpCookie("UserSign", CryptoProvider.GetMD5Hash(UserUniqueData + "sugar"));
            HttpCookie cookieId = new HttpCookie("UserId", UserId.ToString());
            cookieSign.Expires = DateTime.Now.AddDays(3);
            cookieId.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(cookieSign);
            Response.Cookies.Add(cookieId);
        }
    }
}