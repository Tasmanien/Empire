app.config(function ($routeProvider) {
    $routeProvider
        .when('/wallets',
            {
                controller: 'walletController',
                templateUrl: 'app/views/wallets.html'
            });

    $routeProvider.otherwise({ redirectTo: "/wallets" });
});