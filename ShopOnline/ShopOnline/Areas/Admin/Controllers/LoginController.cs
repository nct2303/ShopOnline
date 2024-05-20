using Model.DAO;
using ShopOnline.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using ShopOnline.Commons;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new User_DAO();
                var result = dao.Login(model.Username, model.Password);
                if(result == 1)
                {
                    var user = dao.getItem(model.Username);
                    var session = new UserLogin();
                    session.UserName = user.UserName;
                    session.Password = user.Password;
                    session.Email = user.Email;
                    session.UserID = user.ID;
                    session.Fullname = user.FullName;
                    Session.Add(TempFunc.USER_SESSION, session);
                    return RedirectToAction("Index","AdminHome");
                }
                else if(result == 0) 
                {
                    ModelState.AddModelError("","Sai mật khẩu");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ!");
                }
            }
            return View("Index");
        }
    }
}