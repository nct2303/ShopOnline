using Model.DAO;
using Model.EntityFramwork;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ShopeeOnlineDBContext db = new ShopeeOnlineDBContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Assets/Image/"), fileName);
                    imageFile.SaveAs(path);
                    product.Image = "~/Assets/Image/" + fileName; // Lưu đường dẫn của hình ảnh trong cơ sở dữ liệu
                }

                // Lưu thông tin sản phẩm vào cơ sở dữ liệu
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Detail","Product");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new AddProDuct_DAO();
                var statisticDao = new Statictis_DAO();
                var pd = dao.GetProductById(id);
                if (pd != null)
                {
                    var del = dao.Delete(pd.product_id);
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
            var dao = new AddProDuct_DAO();
            var product = dao.GetAllProducts();
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
        public ActionResult Edit(int id)
        {
            var dao = new AddProDuct_DAO();
            return View(dao.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Edit(Product pd)
        {
            if(ModelState.IsValid)
            {
                var dao = new AddProDuct_DAO();
                Product product = dao.Update(pd);
                return RedirectToAction("Detail");
            }
            else
            {
                return HttpNotFound("Khong tim thay");
            }
        }
        public ActionResult DetailsProduct()
        {
            return View("DetailsProduct");
        }
    }
}
