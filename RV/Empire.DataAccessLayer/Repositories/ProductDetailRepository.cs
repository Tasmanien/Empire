using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public class ProductDetailRepository : BaseRepository<ProductDetail>
	{
		public ProductDetailRepository(EmpireContext context)
			: base(context)
		{

		}
	}
}
