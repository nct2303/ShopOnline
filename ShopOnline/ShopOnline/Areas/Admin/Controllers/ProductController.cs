using Model.DAO;
using Model.EntityFramwork;
using System.Linq;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
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
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new AddProDuct_DAO();
                var pd = dao.Add(product);
                if (pd != null)
                {
                    return RedirectToAction("Detail", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi thêm sản phẩm");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                var dao = new AddProDuct_DAO();
                var pd = dao.GetProductById(id);
                if (pd != null)
                {
                    var del = dao.Delete(pd.Id);
                    if (del != null)
                    {
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

    }
}
