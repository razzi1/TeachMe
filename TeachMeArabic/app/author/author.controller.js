(function () {
    'use strict';

    angular.module('app').controller('AuthorController', ['dataFactory', '$routeParams', AuthorController]);

    function AuthorController(dataFactory, $routeParams) {
        var vm = this;

        getAuthor($routeParams.id);

        function getAuthor(id) {
            dataFactory.getAuthor(id)
              .then(function (result) {
                  vm.author = result.data;
              },
              function (error) {
                  alert(error.message);
              });
        }
    }
})();