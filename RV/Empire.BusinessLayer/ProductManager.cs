using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer;

namespace Empire.BusinessLayer
{
	public static class ProductManager
	{
		public static List<Product> GetAllProducts()
		{
			using (EmpireContext database = new EmpireContext())
			{
				if (!database.Products.Any())
				{
					database.Products.Add(new Product { Name = "PURE WHEY" });
					database.Products.Add(new Product { Name = "RECOVERY BCAA-G" });
					database.SaveChanges();
				}

				return database.Products.OrderBy(x => x.Id).ToList();
			}
		}
		public static ProductDetail GetProductDetail(int productId)
		{
			using (EmpireContext database = new EmpireContext())
			{
				if (!database.ProductDetails.Any())
				{
					foreach (Product product in database.Products)
					{
						database.ProductDetails.Add(new ProductDetail { Product = product, Description = product.Name + " DESCRIPTION", Price = 33.90m });
					}

					database.SaveChanges();
				}

				return database.ProductDetails.FirstOrDefault(x => x.Product.Id == productId);
			}
		}
	}
}
