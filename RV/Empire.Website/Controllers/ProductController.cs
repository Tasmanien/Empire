using System.Web.Mvc;
using Empire.BusinessLayer;

namespace Empire.Website.Controllers
{
	public class ProductController : Controller
	{
		public ActionResult Index()
		{
			return View(ProductService.Instance.GetProducts());
		}
		public JsonResult Details(int productId)
		{
			return Json(ProductService.Instance.GetProductDetails(productId), JsonRequestBehavior.AllowGet);
		}
	}
}