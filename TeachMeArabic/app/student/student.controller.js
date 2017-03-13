(function () {
    'use strict';

    angular.module('app').controller('StudentController', ['dataFactory', '$routeParams', StudentController]);

    function StudentController(dataFactory, $routeParams) {
        var vm = this;

        getStudent($routeParams.id);

        function getStudent(id) {
            dataFactory.getStudent(id)
              .then(function (result) {
                  vm.student = result.data;
              },
              function (error) {
                  alert(error.message);
              });
        }
    }
})();