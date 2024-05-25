using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web;
using System.Web.SessionState;

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
        public Product GetProductById(string productId)
        {
            return db.Products.FirstOrDefault(x => x.Id == productId);
        }
        public ActionResult Search(string keyword)
        {
            // Tìm kiếm sản phẩm dựa trên từ khóa
            var products = db.Products.Where(p => p.Name.Contains(keyword)).ToList();
            if (products != null && products.Count > 0)
            {
                return View(products);
            }
            else
            {
                // Nếu không tìm thấy sản phẩm, chuyển hướng đến trang NothingPage
                return RedirectToAction("NothingPage");
            }
            // Trả về view kết quả tìm kiếm với model là danh sách sản phẩm tìm được
        }

        public ActionResult Cart()
        {
            var cart = Session["Cart"] as List<Product>;
            return View(cart ?? new List<Product>());
        }

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                var cart = Session["Cart"] as List<Product> ?? new List<Product>();
                cart.Add(product);
                Session["Cart"] = cart;
            }
            TempData["CartMessage"] = "Product added to cart successfully!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(string id)
        {
            var cart = Session["Cart"] as List<Product>;
            if (cart != null)
            {
                var product = cart.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    cart.Remove(product);
                    Session["Cart"] = cart;
                }
            }
            return RedirectToAction("Cart");
        }
        public ActionResult NothingPage()
        {
            return View();
        }
    }
}