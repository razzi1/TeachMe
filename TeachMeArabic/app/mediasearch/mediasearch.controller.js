(function () {
    'use strict';

    angular.module('app').controller('MediaSearchController', ['$scope', 'dataFactory', 'searchCriteria', MediaSearchController]);

    function MediaSearchController($scope, dataFactory, searchCriteria) {
        var vm = this;
        vm.mediaTypes =
        {
            Text: 0,
            Html: 1,
            Image: 2,
            Video: 3
        };
        vm.isLoading = true;
        vm.isSearching = false;
        vm.searchPanelIsVisible = true;
        vm.mediaCategories = [];
        vm.languages = [];
        vm.mediaList = null;
        vm.search = searchCriteria;
        vm.searchForMedia = searchForMedia;
        vm.toggleSearchPanel = toggleSearchPanel;

        getMediaCount();
        $scope.numPerPage = 6;
        $scope.setPage = function () {
            $scope.data = getMediaPage(($scope.currentPage - 1) * $scope.numPerPage, $scope.numPerPage);
        };
        $scope.$watch('currentPage', $scope.setPage);

        loadLanguages();
        loadMediaCategories();

        if (vm.search.alreadySearched)
            searchForMedia();

        $('#search').collapse("show");

        function getMediaCount() {
            dataFactory.getMediaCount()
              .then(function (result) {
                  $scope.noOfPages = Math.ceil(result.data.mediaCount / $scope.numPerPage);
              },
              function (error) {
                  alert(error.message);
              });
        }

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
              },
              function (error) {
                  alert(error.message);
              });
        }

        function getMediaPage(offset, limit) {
            vm.search.offset = offset;
            vm.search.limit = limit;
            return searchForMedia();
        }

        function searchForMedia() {
            vm.isSearching = true;
            vm.isLoading = true;
            dataFactory.search(vm.search)
                .then(function (response) {
                    vm.mediaList = response.data;
                    vm.isSearching = false;
                    if (!vm.search.alreadySearched)
                        $scope.currentPage = 1;
                    vm.search.alreadySearched = true;
                    vm.isLoading = false;
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