using System;
using System.ComponentModel.DataAnnotations;

namespace Empire.Database.Entities
{
	public class EntityBase
	{
		[Key]
		public int Id { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
