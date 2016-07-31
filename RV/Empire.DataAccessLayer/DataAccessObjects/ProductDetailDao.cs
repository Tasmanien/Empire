using System;
using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer.Exceptions;
using Empire.DataAccessLayer.Interfaces;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.DataAccessLayer.DataAccessObjects
{
	public class ProductDetailDao : IProductDetailDao
	{
		private static IProductDetailDao _instance;
		public static IProductDetailDao Instance => _instance ?? (_instance = new ProductDetailDao());

		public void Create(ProductDetailDto product)
		{
			throw new NotImplementedException();
		}
		public void Update(ProductDetailDto product)
		{
			throw new NotImplementedException();
		}
		public void Delete(ProductDetailDto product)
		{
			throw new NotImplementedException();
		}

		public ProductDetailDto GetById(int id)
		{
			throw new NotImplementedException();
		}
		public List<ProductDetailDto> GetAll()
		{
			throw new NotImplementedException();
		}

		public ProductDetailDto GetByProductId(int productId)
		{
			try
			{
				using (EmpireContext context = new EmpireContext())
				{
					return GetDto(context.ProductDetails.Single(x => x.ProductId == productId));
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while getting details for a product ({productId}).", ex);
			}
		}
		
		private static ProductDetailDto GetDto(ProductDetail productDetail)
		{
			return new ProductDetailDto
			{
				Id = productDetail.Id,
				Description = productDetail.Description,
				Price = productDetail.Price
			};
		}
		private static ProductDetail GetEntity(ProductDetailDto productDetail)
		{
			return new ProductDetail
			{
				Id = productDetail.Id,
				Description = productDetail.Description,
				Price = productDetail.Price
			};
		}
	}
}
