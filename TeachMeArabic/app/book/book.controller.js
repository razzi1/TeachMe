(function () {
    'use strict';

    angular.module('app').controller('BookController', ['dataFactory', '$routeParams', BookController]);

    function BookController(dataFactory, $routeParams) {
        var vm = this;
        vm.isLoading = true;
        vm.bookDetailsPanelIsVisible = true;
        vm.searchPanelIsVisible = true;

        vm.firstPage = firstPage;
        vm.lastPage = lastPage;
        vm.nextPage = nextPage;
        vm.previousPage = previousPage;
        vm.goToPage = goToPage;
        vm.toggleBookDetailsPanel = toggleBookDetailsPanel;

        getBook($routeParams.id);

        function getBook(id) {
            dataFactory.getBook(id)
              .then(function (result) {
                  vm.book = result.data;
                  vm.book.page = 1;
                  vm.isLoading = false;
                        toggleBookDetailsPanel();
                    },
              function (error) {
                  alert(error.message);
              });
        }

        function goToPage() {
            if (isNaN(vm.pageNumber) || vm.pageNumber < 1 || vm.pageNumber > vm.book.pages) vm.pageNumber = vm.book.page;
            else vm.book.page = vm.pageNumber;
        }

        function firstPage() {
            vm.book.page = 1;
        }

        function lastPage() {
            vm.book.page = vm.book.pages;
        }

        function nextPage() {
            vm.book.page++;
            if (vm.book.page > vm.book.pages) vm.book.page = 1;
        }

        function previousPage() {
            vm.book.page--;
            if (vm.book.page < 1) vm.book.page = vm.book.pages;
        }

        function toggleBookDetailsPanel() {
            $('#bookDetails').collapse("toggle");
            vm.bookDetailsPanelIsVisible = !vm.bookDetailsPanelIsVisible;
        }
    }
})();