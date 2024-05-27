using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class LoginPageModel
    {
        public string customer_id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập username")]
        public string customer_username {  get; set; }
        [Required(ErrorMessage = "Vui lòng nhập password")]
        public string customer_password { get; set; }
    }
}