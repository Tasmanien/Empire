using WalletViewer.Core;

namespace WalletViewer.Services
{
    public interface IPriceService
    {
        decimal GetPrice(Currency currency, Currency baseCurrency);
    }
}