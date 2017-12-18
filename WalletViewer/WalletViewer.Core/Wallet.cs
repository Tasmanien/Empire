namespace WalletViewer.Core
{
    public class Wallet
    {
        public Currency Currency { get; }
        public string Address { get; }

        public Wallet(Currency currency, string address)
        {
            Currency = currency;
            Address = address;
        }
    }
}