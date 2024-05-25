using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        ShopeeOnlineDBContext db = null;
        public ProductDetailController()
        {
            db = new ShopeeOnlineDBContext();
        }
        public Product GetProductById(string productId)
        {
            return db.Products.FirstOrDefault(x => x.Id == productId);
        }
        public ActionResult Index(string id)
        {
            var product = GetProductById(id);
            return View(product);
        }
    }
}