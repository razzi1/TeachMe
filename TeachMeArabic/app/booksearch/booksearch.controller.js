(function () {
    'use strict';

    angular.module('app').controller('BookSearchController', ['dataFactory', 'searchCriteria', BookSearchController]);

    function BookSearchController(dataFactory, searchCriteria) {
        var vm = this;
        vm.isLoading = true;
        vm.isSearching = false;
        vm.searchPanelIsVisible = true;
        vm.bookTypes = [];
        vm.languages = [];
        vm.search = searchCriteria;
        vm.searchForBooks = searchForBooks;
        vm.toggleSearchPanel = toggleSearchPanel;

        loadLanguages();
        loadBookTypes();

        if (vm.search.alreadySearched)
            searchForBooks();

        $('#search').collapse("show");

        function loadLanguages() {
            dataFactory.getLanguages()
              .then(function (result) {
                  vm.languages = result.data;
                  if (vm.languages.length > 0) {
                      vm.search.selectedLanguage = vm.languages[0];
                  }
              },
              function (error) {
                  alert(error.message);
              });
        }

        function loadBookTypes() {
            dataFactory.getBookTypes()
              .then(function (result) {
                  vm.bookTypes = result.data;
                  if (vm.bookTypes.length > 0) {
                      vm.search.selectedBookType = vm.bookTypes[0];
                  }
                  vm.isLoading = false;
                  toggleSearchPanel();
                  toggleSearchPanel();
              },
              function (error) {
                  alert(error.message);
              });
        }

        function searchForBooks() {
            vm.isSearching = true;
            dataFactory.search(vm.search)
                .then(function (response) {
                    vm.Books = response.data;
                    vm.isSearching = false;
                    vm.search.alreadySearched = true;
                    toggleSearchPanel();
                    toggleSearchPanel();
                }, function (error) {
                    vm.isSearching = false;
                    alert('Unable to load books: ' + error.message);
                });
        }

        function toggleSearchPanel() {
            $('#search').collapse("toggle");
            vm.searchPanelIsVisible = !vm.searchPanelIsVisible;
        }
    }
})();