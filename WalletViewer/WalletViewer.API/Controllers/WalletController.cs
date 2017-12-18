using System.Web.Http;
using WalletViewer.Components;
using WalletViewer.Core;

namespace WalletViewer.API.Controllers
{
    [RoutePrefix("api/wallet")]
    public class WalletController : ApiController
    {
        public IHttpActionResult GetBalance(Currency currency, string address)
        {
            var value = WalletComponent.GetWalletValue(currency, address, Currency.UnitedStatesDollar, Exchange.Kraken, out decimal balance);

            return Ok(new
            {
                balance,
                value
            });
        }
    }
}