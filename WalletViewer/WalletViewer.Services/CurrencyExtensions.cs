using System.Collections.Generic;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public static class CurrencyExtensions
    {
        private static readonly Dictionary<Exchange, IPriceService> PriceService = new Dictionary<Exchange, IPriceService>
        {
            [Exchange.Kraken] = new KrakenPriceService(),
            [Exchange.Poloniex] = new PoloniexPriceService()
        };

        public static decimal GetPrice(this Currency currency, Currency baseCurrency, Exchange exchange)
        {
            return PriceService[exchange].GetPrice(currency, baseCurrency);
        }
    }
}