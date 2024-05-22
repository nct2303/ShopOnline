using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ShopPageController : Controller
    {
        // GET: ShopPage
        ShopeeOnlineDBContext db = null;
        public ShopPageController()
        {
            db = new ShopeeOnlineDBContext();
        }
        public ActionResult Index()
        {
            var product = db.Products.ToList();
            return View(product);
        }
    }
}