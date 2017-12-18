namespace WalletViewer.Services
{
    public interface IBalanceService
    {
        decimal GetAddressBalance(string address);
    }
}