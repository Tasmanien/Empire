using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class CoinbasePriceService : IPriceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://api.coinbase.com/v2/prices/{0}/sell");

        private static readonly Dictionary<Tuple<Currency, Currency>, string> PairCode = new Dictionary<Tuple<Currency, Currency>, string>
        {
            [Tuple.Create(Currency.Bitcoin, Currency.UnitedStatesDollar)] = "BTC-USD",
            [Tuple.Create(Currency.Dash, Currency.UnitedStatesDollar)] = "DASH-USD",
            [Tuple.Create(Currency.Ethereum, Currency.UnitedStatesDollar)] = "ETHU-SD",
            [Tuple.Create(Currency.EthereumClassic, Currency.UnitedStatesDollar)] = "ETC-USD",
            [Tuple.Create(Currency.Litecoin, Currency.UnitedStatesDollar)] = "LTC-USD",
            [Tuple.Create(Currency.Ripple, Currency.UnitedStatesDollar)] = "XRP-USD",

            [Tuple.Create(Currency.Bitcoin, Currency.Euro)] = "BTC-EUR",
            [Tuple.Create(Currency.Dash, Currency.Euro)] = "DASH-EUR",
            [Tuple.Create(Currency.Ethereum, Currency.Euro)] = "ETH-EUR",
            [Tuple.Create(Currency.EthereumClassic, Currency.Euro)] = "ETC-EUR",
            [Tuple.Create(Currency.Litecoin, Currency.Euro)] = "LTC-EUR",
            [Tuple.Create(Currency.Ripple, Currency.Euro)] = "XRP-EUR"
        };

        public decimal GetPrice(Currency currency, Currency baseCurrency)
        {
            var uri = new Uri(string.Format(CultureInfo.InvariantCulture, ApiUri.ToString(), PairCode[Tuple.Create(currency, baseCurrency)]));

            var uriBuilder = new UriBuilder(uri);

            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) })
                {
                    var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                    var result = JsonConvert.DeserializeObject<dynamic>(response);

                    var price = decimal.Parse(result.data.amount.Value, CultureInfo.InvariantCulture);

                    return price;
                }
            }
            catch (Exception ex)
            {
                throw new PriceServiceException(ex.Message, uriBuilder.Uri, currency, baseCurrency);
            }
        }
    }
}