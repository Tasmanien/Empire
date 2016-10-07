using System;

namespace Empire.DataAccessLayer.DataAccessObjects
{
	public abstract class BaseDao
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
