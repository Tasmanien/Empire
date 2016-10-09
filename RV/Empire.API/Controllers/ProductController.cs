using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Empire.BusinessLayer;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.API.Controllers
{
	public class ProductController : ApiController
	{
		public JsonResult<IList<ProductDto>> Get()
		{
			return Json(ProductService.Instance.GetProducts());
		}

		public JsonResult<ProductDetailDto> Get(int id)
		{
			return Json(ProductService.Instance.GetProductDetails(id));
		}

		public void Post([FromBody]string value)
		{

		}

		public void Put(int id, [FromBody]string value)
		{

		}

		public void Delete(int id)
		{

		}
	}
}
