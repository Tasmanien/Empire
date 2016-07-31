using System.Collections.Generic;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.DataAccessLayer.Interfaces
{
	public interface IDataAccessObject<T>
		where T : DataTransferObject
	{
		void Create(T product);
		void Update(T product);
		void Delete(T product);

		T GetById(int id);
		List<T> GetAll();
	}
}
