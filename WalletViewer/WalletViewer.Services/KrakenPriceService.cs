using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class KrakenPriceService : IPriceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://api.kraken.com/0/public/Ticker");

        private static readonly Dictionary<Tuple<Currency, Currency>, string> PairCode = new Dictionary<Tuple<Currency, Currency>, string>
        {
            [Tuple.Create(Currency.Bitcoin, Currency.UnitedStatesDollar)] = "XBTUSD",
            [Tuple.Create(Currency.Dash, Currency.UnitedStatesDollar)] = "DASHUSD",
            [Tuple.Create(Currency.Ethereum, Currency.UnitedStatesDollar)] = "ETHUSD",
            [Tuple.Create(Currency.EthereumClassic, Currency.UnitedStatesDollar)] = "ETCUSD",
            [Tuple.Create(Currency.Litecoin, Currency.UnitedStatesDollar)] = "LTCUSD",
            [Tuple.Create(Currency.Ripple, Currency.UnitedStatesDollar)] = "XRPUSD",

            [Tuple.Create(Currency.Bitcoin, Currency.Euro)] = "XBTEUR",
            [Tuple.Create(Currency.Dash, Currency.Euro)] = "DASHEUR",
            [Tuple.Create(Currency.Ethereum, Currency.Euro)] = "ETHEUR",
            [Tuple.Create(Currency.EthereumClassic, Currency.Euro)] = "ETCEUR",
            [Tuple.Create(Currency.Litecoin, Currency.Euro)] = "LTCEUR",
            [Tuple.Create(Currency.Ripple, Currency.Euro)] = "XRPEUR"
        };

        public decimal GetPrice(Currency currency, Currency baseCurrency)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("pair", PairCode[Tuple.Create(currency, baseCurrency)]);

            var uriBuilder = new UriBuilder(ApiUri)
            {
                Query = parameters.ToString()
            };

            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result.error.HasValues)
                {
                    throw new PriceServiceException(result.error, uriBuilder.Uri, currency, baseCurrency);
                }

                foreach (var pair in result.result)
                {
                    var price = decimal.Parse(result.result[pair.Name].c.First.Value, CultureInfo.InvariantCulture);

                    return price;
                }
            }

            return 0m;
        }
    }
}