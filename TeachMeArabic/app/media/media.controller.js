(function () {
    'use strict';

    angular.module('app').controller('MediaController', ['dataFactory', '$routeParams', '$sce', MediaController]);

    function MediaController(dataFactory, $routeParams, $sce) {
        var vm = this;
        vm.mediaTypes = { Text: 0, Html: 1, Image: 2, Video: 3 };
        vm.config = {
            preload: "none",
            sources: [
                { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.mp4"), type: "video/mp4" },
                { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.webm"), type: "video/webm" },
                { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.ogg"), type: "video/ogg" }
            ],
            tracks: [
                {
                    src: "http://www.videogular.com/assets/subs/pale-blue-dot.vtt",
                    kind: "subtitles",
                    srclang: "en",
                    label: "English",
                    default: ""
                }
            ],
            theme: {
                url: "http://www.videogular.com/styles/themes/default/latest/videogular.css"
            }
        };

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