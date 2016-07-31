using System;

namespace Empire.BusinessLayer.Exceptions
{
	public class BusinessLayerException : Exception
	{
		public int ErrorCode { get; set; }

		public BusinessLayerException()
		{

		}
		public BusinessLayerException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
		public BusinessLayerException(string message)
			: base(message)
		{

		}
	}
}
