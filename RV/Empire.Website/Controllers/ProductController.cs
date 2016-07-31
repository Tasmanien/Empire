using System.Web.Mvc;
using Empire.BusinessLayer;

namespace Empire.Website.Controllers
{
	public class ProductController : Controller
	{
		public ActionResult Index()
		{
			return View(ProductManager.GetAll());
		}

		public JsonResult Details(int productId)
		{
			return Json(ProductManager.GetProductDetails(productId), JsonRequestBehavior.AllowGet);
		}
	}
}