using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Models
{
    public class ProductModel : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}