using System;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class EthereumClassicBalanceService : IBalanceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://api.gastracker.io/addr/{0}");

        private const decimal WeiValue = 1E-18m;

        public decimal GetAddressBalance(string address)
        {
            var uri = new Uri(string.Format(CultureInfo.InvariantCulture, ApiUri.ToString(), address));

            var uriBuilder = new UriBuilder(uri);

            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result.success != null)
                {
                    throw new BalanceServiceException(result.success.Value, uriBuilder.Uri, address);
                }

                var amount = Convert.ToDecimal(result.balance.wei.Value);

                return amount * WeiValue;
            }
        }
    }
}