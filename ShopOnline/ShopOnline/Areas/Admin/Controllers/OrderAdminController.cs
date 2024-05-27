using Model.DAO;
using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        // GET: Admin/
        ShopeeOnlineDBContext db = new ShopeeOnlineDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public Order getOrderByID(int orderID)
        {
            return db.Orders.FirstOrDefault(x => x.order_id == orderID);
        }
        public List<Order>  GetOrders()
        {
            return db.Orders.ToList();
        }
        public Order Delete(int orderId)
        {
            var pd = db.Orders.FirstOrDefault(x => x.order_id == orderId);
            db.Orders.Remove(pd);
            db.SaveChanges();
            return pd;
        }
        [HttpGet]
        public ActionResult Detail()
        {
            var order = GetOrders();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [HttpGet]
        public ActionResult DetailOrder()
        {
            var orders = GetOrders();
            if (orders == null)
            {
                return HttpNotFound();
            }

            var orderDetails = new List<OrderDetail>();
            foreach (var order in orders)
            {
                var orderDetail = getOrderDetailByID(order.order_id.ToString());
                if (orderDetail != null)
                {
                    orderDetails.Add(orderDetail);
                }
            }

            return View(orderDetails);
        }
        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            if(ModelState.IsValid)
            {
                var order = getOrderByID(id);
                if (order != null)
                {
                    var del = Delete(id);
                    if (del != null)
                    {
                        return RedirectToAction("Detail", "Order");
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
        public OrderDetail getOrderDetailByID(string orderID)
        {
            return db.OrderDetails.FirstOrDefault(x => x.order_id == orderID);
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return db.OrderDetails.ToList();
        }
    }
}