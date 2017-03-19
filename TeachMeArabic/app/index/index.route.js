(function () {
    'use strict';

    // Create angular routing
    angular.module('app')
      .config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
            .when('/mediasearch',
            {
                templateUrl: 'app/mediasearch/mediasearch.html',
                controllerAs: 'vm',
                controller: 'MediaSearchController'
            })
            .when('/media/:id',
            {
                templateUrl: 'app/media/media.html',
                controllerAs: 'vm',
                controller: 'MediaController'
            })
            .when('/author/:id',
            {
                templateUrl: 'app/author/author.html',
                controllerAs: 'vm',
                controller: 'AuthorController'
            })
            .when('/studentLogin',
            {
                templateUrl: 'app/studentLogin/studentLogin.html',
                controllerAs: 'vm',
                controller: 'StudentLoginController'
            })
            .when('/',
            {
                templateUrl: 'app/index/index-splash.html',
                controllerAs: 'vm',
                controller: 'IndexController'
            })
            .otherwise(
            {
                redirectTo: '/'
            });
        }]);
})();