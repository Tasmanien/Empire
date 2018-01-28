app.controller('walletController',
    [
        '$scope', 'walletService',
        function($scope, walletService) {

            $scope.symbols = {
                'Bitcoin': 'btc',
                'Dash': 'dash',
                'Ethereum': 'eth',
                'EthereumClassic': 'etc',
                'Litecoin': 'ltc',
                'Ripple': 'xrp'
            };

            $scope.wallets = [];

            $scope.wallets.push({
                'currency': 'Bitcoin',
                'address': '36jRcpGfb8xcPoF1cACVqqgbGKygqAhR3d',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.wallets.push({
                'currency': 'Dash',
                'address': 'XjGbEyY1UTc9JwTXjBg8rku3uJeNpL74HB',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.wallets.push({
                'currency': 'Ethereum',
                'address': '0x76Fc3a689d6cd16801B2b3eDBa93E817cfD5AdF6',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.wallets.push({
                'currency': 'EthereumClassic',
                'address': '0x27fd50689BAb2895461209302596a78272ADe6Af',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.wallets.push({
                'currency': 'Litecoin',
                'address': 'LZ8ZXhwqt27LyMV3AUN51mzbaURWe3iZ5v',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.wallets.push({
                'currency': 'Ripple',
                'address': 'r3LWUrux6VVAkHMk5wNqRBtWyPZewB4guu',
                'balance': 0,
                'value': 0,
                'refreshing': false
            });

            $scope.totalValue = 0;

            $scope.updateBalance = function(wallet) {
                if (wallet.refreshing) {
                    return;
                }
                wallet.refreshing = true;
                walletService.getBalance(wallet).then(function(response) {
                    wallet.balance = response.data.balance;
                    wallet.value = response.data.value;
                    $scope.updateTotalValue();
                    wallet.refreshing = false;
                });
            };

            $scope.updateBalances = function() {
                for (var i = 0; i < $scope.wallets.length; i++) {
                    $scope.updateBalance($scope.wallets[i]);
                }
            };

            $scope.updateTotalValue = function() {
                $scope.totalValue = 0;
                for (var i = 0; i < $scope.wallets.length; i++) {
                    $scope.totalValue += $scope.wallets[i].value;
                }
            };
        }
    ]);