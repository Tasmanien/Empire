using System;
using System.Runtime.Serialization;

namespace WalletViewer.Core
{
    public class BalanceServiceException : Exception
    {
        private Uri Uri { get; }
        private string Address { get; }

        public BalanceServiceException()
        {
        }

        private BalanceServiceException(string message)
            : base(message)
        {
        }

        public BalanceServiceException(string message, Uri uri, string address)
            : this(message)
        {
            Uri = uri;
            Address = address;
        }

        protected BalanceServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public class PriceServiceException : Exception
    {
        private Uri Uri { get; }
        private Currency Currency { get; }
        private Currency BaseCurrency { get; }

        public PriceServiceException()
        {
        }

        private PriceServiceException(string message)
            : base(message)
        {
        }

        public PriceServiceException(string message, Uri uri, Currency currency, Currency baseCurrency)
            : this(message)
        {
            Uri = uri;
            Currency = currency;
            BaseCurrency = baseCurrency;
        }

        protected PriceServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}