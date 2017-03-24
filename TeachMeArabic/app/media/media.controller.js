(function () {
    'use strict';

    angular.module('app').controller('MediaController',
        [
            'dataFactory',
            '$routeParams',
            '$sce',
            MediaController]);

    function MediaController(dataFactory, $routeParams, $sce) {
        var vm = this;
        vm.API = null;

        vm.onPlayerReady = function (API) {
            vm.API = API;
        };

        vm.mediaTypes = { Text: 0, Html: 1, Image: 2, Video: 3 };
        vm.isLoading = true;
        vm.mediaDetailsPanelIsVisible = true;
        vm.searchPanelIsVisible = true;

        vm.firstPage = firstPage;
        vm.lastPage = lastPage;
        vm.nextPage = nextPage;
        vm.previousPage = previousPage;
        vm.goToPage = goToPage;
        vm.toggleMediaDetailsPanel = toggleMediaDetailsPanel;
        vm.gotoChapterStartingPage = gotoChapterStartingPage;

        getMedia($routeParams.id);

        function getMedia(id) {
            dataFactory.getMedia(id)
              .then(function (result) {
                  vm.media = result.data;
                  vm.media.page = 1;
                  vm.isLoading = false;
                  toggleMediaDetailsPanel();
                  if (vm.media.mediaType === vm.mediaTypes.Video) configureVideo();
              },
              function (error) {
                  alert(error.message);
              });
        }

        function configureVideo() {
            vm.config = {
                preload: "none",
                sources: [
                    { src: $sce.trustAsResourceUrl(vm.media.contentPages[vm.media.page - 1].content), type: "video/mp4" }
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
                    url: "Content/videogular.css"
                }
            };
        }

        function gotoChapterStartingPage(chapter) {
            vm.media.page = chapter.startingPage;
            if (vm.media.mediaType === vm.mediaTypes.Video) {
                vm.API.stop();
                vm.config.sources = [
                    { src: $sce.trustAsResourceUrl(vm.media.contentPages[vm.media.page - 1].content), type: "video/mp4" }
                ];
            }
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