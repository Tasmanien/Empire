using System.Collections.Generic;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public static class CurrencyExtensions
    {
        private static readonly Dictionary<Exchange, IPriceService> PriceService = new Dictionary<Exchange, IPriceService>
        {
            [Exchange.Coinbase] = new CoinbasePriceService(),
            [Exchange.Kraken] = new KrakenPriceService(),
            [Exchange.Poloniex] = new PoloniexPriceService()
        };

        public static decimal GetPrice(this Currency currency, Currency baseCurrency)
        {
            foreach (var exchange in new[] { Exchange.Kraken, Exchange.Poloniex, Exchange.Coinbase })
            {
                try
                {
                    return PriceService[exchange].GetPrice(currency, baseCurrency);
                }
                catch
                {

                }
            }

            throw new PriceServiceException();
        }
    }
}