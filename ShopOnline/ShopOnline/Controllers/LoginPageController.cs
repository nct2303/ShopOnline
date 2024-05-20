using Model.DAO;
using ShopOnline.Commons;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class LoginPageController : Controller
    {
        // GET: LoginPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginPageModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new Customer_DAO();
                var result = dao.Login(model.customer_username, model.customer_password);
                if (result == 1)
                {
                    var user = dao.getItem(model.customer_username);
                    var session = new CustomerLogin();
                    session.customer_username = user.customer_username;
                    session.customer_password = user.customer_password;
                    Session.Add(TempFunc.USER_SESSION, session);
                    return RedirectToAction("Index", "Home");

                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ");
                }
            }
            return View("Index");
        }
    }
}