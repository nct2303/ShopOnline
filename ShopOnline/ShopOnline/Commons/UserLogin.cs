using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Commons
{
    [Serializable]
    public class UserLogin
    {
        public string UserID { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Fullname { get; set; }
        public string Email { get; set;}
    }
}