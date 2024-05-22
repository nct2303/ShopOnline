using Model.DAO;
using Model.EntityFramwork;
using ShopOnline.Commons;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class SignupPageController : Controller
    {
        // GET: Account/Register
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new Customer_DAO();
                var customer = new CustomerAccount
                {
                    customer_username = model.Username,
                    customer_password = model.Password
                };

                var result = dao.Add(customer);
                if (result != null)
                {
                    // Đăng ký thành công, chuyển hướng đến trang đăng nhập hoặc trang khác
                    return RedirectToAction("Index", "LoginPage");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công. Vui lòng thử lại.");
                }
            }

            return View(model);
        }
    }

}