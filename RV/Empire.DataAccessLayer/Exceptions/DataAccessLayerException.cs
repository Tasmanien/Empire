using System;

namespace Empire.DataAccessLayer.Exceptions
{
	public class DataAccessLayerException : Exception
	{
		public int ErrorCode { get; set; }

		public DataAccessLayerException()
		{

		}
		public DataAccessLayerException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
		public DataAccessLayerException(string message)
			: base(message)
		{

		}
	}
}
