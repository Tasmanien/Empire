using System;
using System.Globalization;

namespace WalletViewer.Core
{
    public static class DecimalExtensions
    {
        public static string ToString(this decimal source, Currency currency)
        {
            if (currency == Currency.UnitedStatesDollar)
            {
                return source.ToString("c", new CultureInfo("en-US"));
            }
            
            if (currency == Currency.Euro)
            {
                return source.ToString("c", new CultureInfo("fr-BE"));
            }

            throw new ArgumentOutOfRangeException(nameof(currency));
        }
    }
}