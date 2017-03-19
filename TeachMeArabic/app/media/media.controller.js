(function () {
    'use strict';

    angular.module('app').controller('MediaController', ['dataFactory', '$routeParams', MediaController]);

    function MediaController(dataFactory, $routeParams) {
        var vm = this;
        vm.isLoading = true;
        vm.mediaDetailsPanelIsVisible = true;
        vm.searchPanelIsVisible = true;

        vm.firstPage = firstPage;
        vm.lastPage = lastPage;
        vm.nextPage = nextPage;
        vm.previousPage = previousPage;
        vm.goToPage = goToPage;
        vm.toggleMediaDetailsPanel = toggleMediaDetailsPanel;

        getMedia($routeParams.id);

        function getMedia(id) {
            dataFactory.getMedia(id)
              .then(function (result) {
                  vm.media = result.data;
                  vm.media.page = 1;
                  vm.isLoading = false;
                        toggleMediaDetailsPanel();
                    },
              function (error) {
                  alert(error.message);
              });
        }

        function goToPage() {
            if (isNaN(vm.pageNumber) || vm.pageNumber < 1 || vm.pageNumber > vm.media.pages) vm.pageNumber = vm.media.page;
            else vm.media.page = vm.pageNumber;
        }

        function firstPage() {
            vm.media.page = 1;
        }

        function lastPage() {
            vm.media.page = vm.media.pages;
        }

        function nextPage() {
            vm.media.page++;
            if (vm.media.page > vm.media.pages) vm.media.page = 1;
        }

        function previousPage() {
            vm.media.page--;
            if (vm.media.page < 1) vm.media.page = vm.media.pages;
        }

        function toggleMediaDetailsPanel() {
            $('#mediaDetails').collapse("toggle");
            vm.mediaDetailsPanelIsVisible = !vm.mediaDetailsPanelIsVisible;
        }
    }
})();