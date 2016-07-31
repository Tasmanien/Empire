using System;
using System.Collections.Generic;
using Empire.BusinessLayer.Exceptions;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Exceptions;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.BusinessLayer
{
	public static class ProductManager
	{
		public static List<ProductDto> GetAll()
		{
			try
			{
				return ProductDao.Instance.GetAll();
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException("Error while getting all products.", ex);
			}
		}
		public static ProductDetailDto GetProductDetails(int productId)
		{
			try
			{
				return ProductDetailDao.Instance.GetByProductId(productId);
			}
			catch (DataAccessLayerException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BusinessLayerException($"Error while getting details for a product ({productId}).", ex);
			}
		}
	}
}