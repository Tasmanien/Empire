using System;
using System.Linq;
using WalletViewer.Components;
using WalletViewer.Core;

namespace WalletViewer
{
    public class Program
    {
        public static void Main()
        {
            var wallets = new[]
            {
                new Wallet(Currency.Bitcoin, "36jRcpGfb8xcPoF1cACVqqgbGKygqAhR3d"),
                new Wallet(Currency.Dash, "XjGbEyY1UTc9JwTXjBg8rku3uJeNpL74HB"),
                new Wallet(Currency.Ethereum, "0x76Fc3a689d6cd16801B2b3eDBa93E817cfD5AdF6"),
                new Wallet(Currency.EthereumClassic, "0x27fd50689BAb2895461209302596a78272ADe6Af"),
                new Wallet(Currency.Litecoin, "LZ8ZXhwqt27LyMV3AUN51mzbaURWe3iZ5v"),
                new Wallet(Currency.Ripple, "r3LWUrux6VVAkHMk5wNqRBtWyPZewB4guu")
            };

            var baseCurrencies = new[] { Currency.UnitedStatesDollar, Currency.Euro };

            foreach (var baseCurrency in baseCurrencies)
            {
                var walletsValue = wallets.Sum(wallet =>
                {
                    var value = WalletComponent.GetWalletValue(wallet, baseCurrency, out decimal balance);

                    var symbol = wallet.Currency.GetSymbol();

                    var price = value / balance;

                    Console.WriteLine(FormattableString.Invariant($"{balance} {symbol} - {value.ToString(baseCurrency)} ({price.ToString(baseCurrency)}/u)"));

                    return value;
                });

                Console.WriteLine(FormattableString.Invariant($"Total: {walletsValue.ToString(baseCurrency)}"));
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}