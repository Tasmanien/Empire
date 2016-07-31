using System.Web.Mvc;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Interfaces;

namespace Empire.Website.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductDao _productDao = new ProductDao();

		public ActionResult Index()
		{
			return View(_productDao.GetAll());
		}

		public JsonResult Details(int productId)
		{
			return Json(_productDao.GetProductDetails(productId), JsonRequestBehavior.AllowGet);
		}
	}
}