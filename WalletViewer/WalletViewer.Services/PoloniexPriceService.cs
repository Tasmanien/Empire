using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class PoloniexPriceService : IPriceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://poloniex.com/public");

        private static readonly Dictionary<Tuple<Currency, Currency>, string> PairCode = new Dictionary<Tuple<Currency, Currency>, string>
        {
            [Tuple.Create(Currency.Ethereum, Currency.UnitedStatesDollar)] = "USDT_ETH",
            [Tuple.Create(Currency.EthereumClassic, Currency.UnitedStatesDollar)] = "USDT_ETC",
            [Tuple.Create(Currency.Ripple, Currency.UnitedStatesDollar)] = "USDT_XRP"
        };

        public decimal GetPrice(Currency currency, Currency baseCurrency)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("command", "returnTicker");

            var uriBuilder = new UriBuilder(ApiUri)
            {
                Query = parameters.ToString()
            };

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(1) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                var pairCode = PairCode[Tuple.Create(currency, baseCurrency)];

                var ticker = result[pairCode];

                var price = decimal.Parse(ticker.last.Value, CultureInfo.InvariantCulture);

                return price;
            }
        }
    }
}