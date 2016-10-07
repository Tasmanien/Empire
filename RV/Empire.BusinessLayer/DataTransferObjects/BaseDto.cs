using System;

namespace Empire.ServiceLayer.DataTransferObjects
{
	public abstract class BaseDto
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
