using Empire.Database.Entities;
using Empire.ServiceLayer;

namespace Empire.DataAccessLayer.Interfaces
{
	public interface IProductDao : IDataAccessObject<ProductDto>
	{
		void Create(Product product);
		void Update(Product product);
		void Delete(Product product);

		ProductDetailDto GetProductDetails(int productId);
	}
}
