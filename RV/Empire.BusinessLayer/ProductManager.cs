using System.Collections.Generic;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Interfaces;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.BusinessLayer
{
    public static class ProductManager
    {
		private static readonly IProductDao ProductDao = new ProductDao();

		public static List<ProductDto> GetAll()
		{
			return ProductDao.GetAll();
		}

		public static ProductDetailDto GetProductDetails(int productId)
		{
			return ProductDao.GetProductDetails(productId);
		}
	}
}