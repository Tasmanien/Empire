﻿using System.Globalization;

namespace Empire.ServiceLayer.DataTransferObjects
{
	public class ProductDetailDto : DataTransferObject
	{
		public string Description { get; set; }
		public decimal Price { get; set; }

		public string PriceFormatted => Price.ToString("C", CultureInfo.CurrentCulture);
	}
}