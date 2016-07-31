using System.ComponentModel.DataAnnotations.Schema;

namespace Empire.Database.Entities
{
	public class ProductDetail : EntityBase
	{
		public string Description { get; set; }
		public decimal Price { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public virtual Product Product { get; protected set; }
	}
}
