using System.Collections.Generic;
using WalletViewer.Core;

namespace WalletViewer.Services
{
    public static class WalletExtensions
    {
        private static readonly Dictionary<Currency, IBalanceService> BalanceService = new Dictionary<Currency, IBalanceService>
        {
            [Currency.Ethereum] = new EthereumBalanceService(),
            [Currency.EthereumClassic] = new EthereumClassicBalanceService(),
            [Currency.Bitcoin] = new BitcoinBalanceService(),
            [Currency.Litecoin] = new LitecoinBalanceService(),
            [Currency.Dash] = new DashBalanceService(),
            [Currency.Ripple] = new RippleBalanceService()
        };

        public static decimal GetBalance(this Wallet wallet)
        {
            return BalanceService[wallet.Currency].GetAddressBalance(wallet.Address);
        }
    }
}