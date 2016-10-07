using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly EmpireContext Context;

		protected BaseRepository(EmpireContext context)
		{
			Context = context;
		}
	}
}
