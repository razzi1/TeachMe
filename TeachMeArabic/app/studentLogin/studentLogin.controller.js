(function () {
    'use strict';

    angular.module('app').controller('StudentLoginController', ['dataFactory', '$location', StudentLoginController]);

    function StudentLoginController(dataFactory, $location) {
        var vm = this;
        vm.login = {
            username: null,
            password: null,
            loginFailed : false
        }

        vm.checkStudentLogin = checkStudentLogin;

        function checkStudentLogin() {
            dataFactory.checkStudentLogin(vm.login)
              .then(function (result) {
                  vm.studentLoginResult = result.data;
                        if (vm.studentLoginResult.IsSuccessful)
                            $location.path("/app/student/" + vm.studentLoginResult.studentId);
                        else
                            vm.loginFailed = true;
                    },
              function (error) {
                  alert(error.message);
              });
        }
    }
})();