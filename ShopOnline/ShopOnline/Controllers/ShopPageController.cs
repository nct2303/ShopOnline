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
        public ActionResult Search(string keyword)
        {
            // Tìm kiếm sản phẩm dựa trên từ khóa
            var products = db.Products.Where(p => p.Name.Contains(keyword)).ToList();

            // Trả về view kết quả tìm kiếm với model là danh sách sản phẩm tìm được
            return View(products);
        }

    }
}