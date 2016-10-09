using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public class UserRepository : BaseRepository<User>
	{
		public UserRepository(EmpireContext context)
			: base(context)
		{

		}
	}
}
