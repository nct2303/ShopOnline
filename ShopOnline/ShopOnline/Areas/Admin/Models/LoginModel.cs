using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập username")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}