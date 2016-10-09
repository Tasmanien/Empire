using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public class ProductRepository : BaseRepository<Product>
	{
		public ProductRepository(EmpireContext context)
			: base(context)
		{

		}
	}
}
