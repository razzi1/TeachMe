(function () {
    'use strict';

    angular.module('app').controller('MediaSearchController', ['dataFactory', 'searchCriteria', MediaSearchController]);

    function MediaSearchController(dataFactory, searchCriteria) {
        var vm = this;
        vm.isLoading = true;
        vm.isSearching = false;
        vm.searchPanelIsVisible = true;
        vm.mediaCategories = [];
        vm.languages = [];
        vm.mediaList = null;
        vm.search = searchCriteria;
        vm.searchForMedia = searchForMedia;
        vm.toggleSearchPanel = toggleSearchPanel;

        loadLanguages();
        loadMediaCategories();

        if (vm.search.alreadySearched)
            searchForMedia();

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

        function loadMediaCategories() {
            dataFactory.getMediaCategories()
              .then(function (result) {
                  vm.mediaCategories = result.data;
                  if (vm.mediaCategories.length > 0) {
                      vm.search.selectedCategory = vm.mediaCategories[0];
                  }
                  vm.isLoading = false;
                  toggleSearchPanel();
                  toggleSearchPanel();
              },
              function (error) {
                  alert(error.message);
              });
        }

        function searchForMedia() {
            vm.isSearching = true;
            dataFactory.search(vm.search)
                .then(function (response) {
                    vm.mediaList = response.data;
                    vm.isSearching = false;
                    vm.search.alreadySearched = true;
                    toggleSearchPanel();
                    toggleSearchPanel();
                }, function (error) {
                    vm.isSearching = false;
                    alert('Unable to load media: ' + error.message);
                });
        }

        function toggleSearchPanel() {
            $('#search').collapse("toggle");
            vm.searchPanelIsVisible = !vm.searchPanelIsVisible;
        }
    }
})();