using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Commons
{
    [Serializable]
    public class CustomerLogin
    {
        public string customer_username {  get; set; }
        public string customer_password { get; set; }
    }
}