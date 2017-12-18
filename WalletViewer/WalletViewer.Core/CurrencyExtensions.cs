using System.Collections.Generic;

namespace WalletViewer.Core
{
    public static class CurrencyExtensions
    {
        private static readonly Dictionary<Currency, string> Symbol = new Dictionary<Currency, string>
        {
            [Currency.Bitcoin] = "BTC",
            [Currency.Dash] = "DASH",
            [Currency.Ethereum] = "ETH",
            [Currency.EthereumClassic] = "ETC",
            [Currency.Litecoin] = "LTC",
            [Currency.Ripple] = "XRP"
        };

        public static string GetSymbol(this Currency currency)
        {
            return Symbol[currency];
        }
    }
}