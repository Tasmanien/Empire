using System;
using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer.Interfaces;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer;

namespace Empire.DataAccessLayer.DataAccessObjects
{
	public class ProductDao : IProductDao
	{
		public void Create(Product product)
		{
			throw new NotImplementedException();
		}
		public void Update(Product product)
		{
			throw new NotImplementedException();
		}
		public void Delete(Product product)
		{
			throw new NotImplementedException();
		}

		public ProductDto GetById(int id)
		{
			using (EmpireContext context = new EmpireContext())
			{
				return GetDto(context.Products.Single(x => x.Id == id));
			}
		}
		public List<ProductDto> GetAll()
		{
			using (EmpireContext database = new EmpireContext())
			{
				return database.Products.Select(GetDto).ToList();
			}
		}

		public ProductDetailDto GetProductDetails(int productId)
		{
			using (EmpireContext context = new EmpireContext())
			{
				return GetDto(context.ProductDetails.Single(x => x.ProductId == productId));
			}
		}

		private static ProductDto GetDto(Product product)
		{
			return new ProductDto
			{
				Id = product.Id,
				Name = product.Name
			};
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
	}
}
