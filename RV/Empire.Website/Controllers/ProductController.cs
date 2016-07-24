using System.Web.Mvc;
using Empire.DataAccessLayer;

namespace Empire.Website.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
			return View(ProductManager.GetAllProducts());
        }
		
		public JsonResult Details(int productId)
		{
			return Json(ProductManager.GetProductDetail(productId), JsonRequestBehavior.AllowGet);
		}
    }
}