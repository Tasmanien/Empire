using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer.Interfaces;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.DataAccessLayer.DataAccessObjects
{
	public class ProductDao : IProductDao
	{
		public void Create(ProductDto product)
		{
			using (EmpireContext context = new EmpireContext())
			{
				context.Products.Add(GetEntity(product));

				context.SaveChanges();
			}
		}
		public void Update(ProductDto product)
		{
			using (EmpireContext context = new EmpireContext())
			{
				Product item = context.Products.Single(x => x.Id == product.Id);

				item.Name = product.Name;
				
				context.SaveChanges();
			}
		}
		public void Delete(ProductDto product)
		{
			using (EmpireContext context = new EmpireContext())
			{
				Product item = context.Products.Single(x => x.Id == product.Id);

				context.Products.Remove(item);

				context.SaveChanges();
			}
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

		private static Product GetEntity(ProductDto product)
		{
			return new Product
			{
				Id = product.Id,
				Name = product.Name
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
