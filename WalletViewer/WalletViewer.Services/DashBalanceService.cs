using System;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;

namespace WalletViewer.Services
{
    public class DashBalanceService : IBalanceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://api.blockcypher.com/v1/dash/main/addrs/{0}/balance");

        private const decimal SatoshiValue = 1E-8m;

        public decimal GetAddressBalance(string address)
        {
            var uri = new Uri(string.Format(CultureInfo.InvariantCulture, ApiUri.ToString(), address));

            var uriBuilder = new UriBuilder(uri);

            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                var amount = Convert.ToDecimal(result.balance.Value);

                return amount * SatoshiValue;
            }
        }
    }
}