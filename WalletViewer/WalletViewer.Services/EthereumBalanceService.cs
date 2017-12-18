using System;
using System.Globalization;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class EthereumBalanceService : IBalanceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://api.etherscan.io/api");

        private const decimal WeiValue = 1E-18m;

        public decimal GetAddressBalance(string address)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("module", "account");
            parameters.Add("action", "balance");
            parameters.Add("address", address);

            var uriBuilder = new UriBuilder(ApiUri)
            {
                Query = parameters.ToString()
            };

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(1) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result.message != "OK")
                {
                    throw new BalanceServiceException(result.result.Value, uriBuilder.Uri, address);
                }

                var amount = decimal.Parse(result.result.Value, CultureInfo.InvariantCulture);

                return amount * WeiValue;
            }
        }
    }
}