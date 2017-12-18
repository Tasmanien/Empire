app.factory('walletService',
    function($http) {
        return {
            getBalance: function(wallet) {
                //return $http.get('http://localhost/api/wallet/getbalance', { 'params': wallet });
                return $http.get('http://walletviewerapi.azurewebsites.net/api/wallet/getbalance',
                    { 'params': wallet });
            }
        };
    });