﻿using Model.DAO;
using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                var dao = new Customer_DAO();
                var statisticDao = new Statictis_DAO();
                var pd = dao.getCustomerById(id);
                if (pd != null)
                {
                    var del = dao.Delete(pd.customer_id);
                    if (del != null)
                    {

                        //statisticDao.UpdateStatistics("Delete");
                        return RedirectToAction("Detail", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi xóa sản phẩm");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Không tìm thấy sản phẩm");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Detail()
        {
            var dao = new Customer_DAO();
            var product = dao.getAllCustomer();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        /*public ActionResult DetailStatictis()
        {
            var dao = new Statictis_DAO();
            //var statistics = dao.GetStatistics(); // Lấy dữ liệu thống kê từ cơ sở dữ liệu

            return View(statistics);
        }*/
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new AddProDuct_DAO();
            return View(dao.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Edit(Product pd)
        {
            if (ModelState.IsValid)
            {
                var dao = new AddProDuct_DAO();
                Product product = dao.Update(pd);
                return RedirectToAction("Detail");
            }
            else
            {
                return HttpNotFound("Khong tim thay");
            }
            return View("Index");
        }
        public ActionResult DetailsProduct()
        {
            return View("DetailsProduct");
        }
    }
}