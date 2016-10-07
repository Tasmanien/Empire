using System;
using System.Web;
using System.Web.Mvc;
using Empire.BusinessLayer;
using Empire.BusinessLayer.Exceptions;
using Empire.DataAccessLayer.Exceptions;

namespace Empire.Website.Controllers
{
	public class ProductController : Controller
	{
		public ActionResult Index()
		{
			try
			{
				return View(ProductService.GetAll());
			}
			catch (DataAccessLayerException ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR CODE: {ex.ErrorCode})");
			}
			catch (BusinessLayerException ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR CODE: {ex.ErrorCode})");
			}
			catch (Exception ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR MESSAGE: {ex.Message})");
			}
		}
		public JsonResult Details(int productId)
		{
			try
			{
				return Json(ProductService.GetProductDetails(productId), JsonRequestBehavior.AllowGet);
			}
			catch (DataAccessLayerException ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR CODE: {ex.ErrorCode})");
			}
			catch (BusinessLayerException ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR CODE: {ex.ErrorCode})");
			}
			catch (Exception ex)
			{
				throw new HttpException(500, $"Internal Server Error (ERROR MESSAGE: {ex.Message})");
			}
		}
	}
}