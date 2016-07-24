using System.Globalization;

namespace Empire.DataAccessLayer
{
	public class ProductDetail : EntityBase
	{
		public string Description { get; set; }
		public decimal Price { get; set; }
		public Product Product { get; set; }

		public string PriceFormatted => Price.ToString("C", CultureInfo.CurrentCulture);
	}
}
