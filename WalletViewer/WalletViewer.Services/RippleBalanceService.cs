using System;
using System.Globalization;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class RippleBalanceService : IBalanceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://data.ripple.com/v2/accounts/{0}/balances");

        public decimal GetAddressBalance(string address)
        {
            var uri = new Uri(string.Format(CultureInfo.InvariantCulture, ApiUri.ToString(), address));

            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("currency", "XRP");

            var uriBuilder = new UriBuilder(uri)
            {
                Query = parameters.ToString()
            };

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(1) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result.result != "success")
                {
                    throw new BalanceServiceException(result.result.Value, uriBuilder.Uri, address);
                }

                var amount = decimal.Parse(result.balances[0].value.Value, CultureInfo.InvariantCulture);

                return amount;
            }
        }
    }
}