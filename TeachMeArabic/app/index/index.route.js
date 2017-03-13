(function () {
    'use strict';

    // Create angular routing
    angular.module('app')
      .config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
            .when('/booksearch',
            {
                templateUrl: 'app/booksearch/booksearch.html',
                controllerAs: 'vm',
                controller: 'BookSearchController'
            })
            .when('/book/:id',
            {
                templateUrl: 'app/book/book.html',
                controllerAs: 'vm',
                controller: 'BookController'
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