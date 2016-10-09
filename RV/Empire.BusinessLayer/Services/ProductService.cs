using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer.Repositories;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.BusinessLayer
{
	public class ProductService
	{
		private EmpireContext _context = new EmpireContext();

		private ProductRepository _productRepository;
		private ProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(_context));

		private ProductDetailRepository _productDetailRepository;
		private ProductDetailRepository ProductDetailRepository => _productDetailRepository ?? (_productDetailRepository = new ProductDetailRepository(_context));

		private static ProductService _instance;
		public static ProductService Instance => _instance ?? (_instance = new ProductService());

		private static Product Convert(ProductDto item)
		{
			return new Product
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}
		private static ProductDto Convert(Product item)
		{
			return new ProductDto
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}

		private static ProductDetail Convert(ProductDetailDto item)
		{
			return new ProductDetail
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price
			};
		}
		private static ProductDetailDto Convert(ProductDetail item)
		{
			return new ProductDetailDto
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Description = item.Description,
				Price = item.Price
			};
		}

		public IList<ProductDto> GetProducts()
		{
			return ProductRepository.Get().Select(Convert).ToList();
		}
		public ProductDetailDto GetProductDetails(int productId)
		{
			return Convert(ProductDetailRepository.Get(x => x.ProductId == productId).FirstOrDefault());
		}
	}
}