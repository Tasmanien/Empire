using System;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public class EthereumClassicBalanceService : IBalanceService
    {
        private static readonly Uri ApiUri = new Uri(@"https://etcchain.com/api/v1/getAddressBalance");

        public decimal GetAddressBalance(string address)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("address", address);

            var uriBuilder = new UriBuilder(ApiUri)
            {
                Query = parameters.ToString()
            };

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(1) })
            {
                var response = client.GetStringAsync(uriBuilder.ToString()).Result;

                var result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result.error != null)
                {
                    throw new BalanceServiceException(result.error.Value, uriBuilder.Uri, address);
                }

                var amount = Convert.ToDecimal(result.balance.Value);

                return amount;
            }
        }
    }
}