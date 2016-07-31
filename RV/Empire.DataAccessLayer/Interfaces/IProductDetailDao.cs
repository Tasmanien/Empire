using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.DataAccessLayer.Interfaces
{
	public interface IProductDetailDao : IDataAccessObject<ProductDetailDto>
	{
		ProductDetailDto GetByProductId(int productId);
	}
}
