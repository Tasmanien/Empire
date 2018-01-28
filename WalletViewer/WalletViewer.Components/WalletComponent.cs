using WalletViewer.Core;
using WalletViewer.Services;

namespace WalletViewer.Components
{
    public static class WalletComponent
    {
        public static decimal GetWalletValue(Wallet wallet, Currency baseCurrency, out decimal balance)
        {
            balance = wallet.GetBalance();

            var price = wallet.Currency.GetPrice(baseCurrency);

            var value = balance * price;

            return value;
        }

        public static decimal GetWalletValue(Currency currency, string address, Currency baseCurrency, out decimal balance)
        {
            var wallet = new Wallet(currency, address);

            return GetWalletValue(wallet, baseCurrency, out balance);
        }
    }
}