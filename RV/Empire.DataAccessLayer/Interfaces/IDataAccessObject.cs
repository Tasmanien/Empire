using System.Collections.Generic;
using Empire.ServiceLayer;

namespace Empire.DataAccessLayer.Interfaces
{
	public interface IDataAccessObject<T>
		where T : DataTransferObject
	{
		T GetById(int id);
		List<T> GetAll();
	}
}
