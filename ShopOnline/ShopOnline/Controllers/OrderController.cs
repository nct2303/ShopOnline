using Model.EntityFramwork;
using System;
using System.Linq;
using System.Web.Mvc;
using ShopOnline.Commons;
using System.Collections.Generic;

namespace ShopOnline.Controllers
{
    public class OrderController : Controller
    {
        // Tạo instance của DbContext
        ShopeeOnlineDBContext db = new ShopeeOnlineDBContext();

        // Trang index
        public ActionResult Index()
        {
            return View();
        }

        // Phương thức lấy thông tin tài khoản khách hàng theo username
        public CustomerAccount getItem(string username)
        {
            return db.CustomerAccounts.FirstOrDefault(x => x.customer_username == username);
        }

        // Phương thức Checkout
        public ActionResult Checkout()
        {
            // Lấy thông tin phiên (session)
            var session = (CustomerLogin)Session[TempFunc.USER_SESSION];
            if (session != null)
            {
                // Lấy thông tin khách hàng từ database
                var customer = getItem(session.customer_username);
                if (customer != null)
                {
                    // Tạo đơn hàng mới
                    var orderItem = new Order
                    {
                        customer_username = customer.customer_username, // Gán username của khách hàng cho đơn hàng
                        Status = 1,
                        CreateDate = DateTime.Now
                    };
                    db.Orders.Add(orderItem);
                    db.SaveChanges();

                    var cart = Session["Cart"] as List<Product>;
                    if (cart != null)
                    {
                        foreach (var product in cart)
                        {
                            string quantity = Request.Form["quantity_" + product.product_id];
                            var orderDetail = new OrderDetail
                            {
                                order_id = orderItem.order_id.ToString(),
                                product_id = product.product_id.ToString(),
                                orderdetail_quanlity = quantity,
                                orderdetail_price = product.Price.ToString()
                                // Đã xóa dòng code gán giá trị cho cột identity (nếu có)
                            };
                            db.OrderDetails.Add(orderDetail);
                        }
                        db.SaveChanges();
                    }
                    Session.Remove("Cart");
                    TempData["success"] = "Đơn hàng đã được tạo";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Xử lý khi không tìm thấy thông tin của khách hàng
                    TempData["error"] = "Không tìm thấy thông tin của khách hàng";
                    return RedirectToAction("Cart", "ShopPage");
                }
            }
            else
            {
                // Xử lý khi không có thông tin phiên (session)
                TempData["error"] = "Phiên làm việc của bạn đã hết. Vui lòng đăng nhập lại.";
                return RedirectToAction("Login", "LoginPage");
            }
        }

        // Trang giỏ hàng
        public ActionResult Delete()
        {
            // Lấy thông tin giỏ hàng từ session
            var cart = Session["Cart"] as List<Product>;
            if (cart != null)
            {
                // Xử lý logic xóa giỏ hàng (ví dụ: xóa toàn bộ sản phẩm trong giỏ)
                cart.Clear();
                Session["Cart"] = cart; // Lưu lại giỏ hàng sau khi xóa

                TempData["success"] = "Giỏ hàng đã được xóa";
            }
            else
            {
                TempData["error"] = "Không có sản phẩm trong giỏ hàng";
            }

            return RedirectToAction("Cart", "ShopPage");
        }

    }
}