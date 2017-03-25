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
        vm.VideoApi = null;

        vm.mediaTypes = { Text: 0, Html: 1, Image: 2, Video: 3 };
        vm.isLoading = true;
        vm.mediaDetailsPanelIsVisible = true;

        // functions called from html
        vm.firstPage = firstPage;
        vm.lastPage = lastPage;
        vm.nextPage = nextPage;
        vm.previousPage = previousPage;
        vm.goToPage = goToPage;
        vm.toggleMediaDetailsPanel = toggleMediaDetailsPanel;
        vm.gotoChapterStartingPage = gotoChapterStartingPage;
        vm.onPlayerReady = onPlayerReady;

        // Get media data from the server
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

        function gotoChapterStartingPage(chapter) {
            if (chapter.startingPage === vm.media.page) return;
            vm.media.page = chapter.startingPage;
            setCurrentVideoBasedOnPage();
        }

        // Video supporting functions
        function configureVideo() {
            vm.config = {
                preload: "none",
                sources: [
                    { src: $sce.trustAsResourceUrl(vm.media.contentPages[vm.media.page - 1].content), type: "video/mp4" }
                ],
                //tracks: [
                //    {
                //        src: "http://www.videogular.com/assets/subs/pale-blue-dot.vtt",
                //        kind: "subtitles",
                //        srclang: "en",
                //        label: "English",
                //        default: ""
                //    }
                //],
                theme: {
                    url: "Content/videogular.css"
                }
            };
        }

        function onPlayerReady(videoApi) {
            vm.VideoApi = videoApi;
        };


        function setCurrentVideoBasedOnPage() {
            if (vm.media.mediaType !== vm.mediaTypes.Video) return;
            vm.VideoApi.stop();
            vm.config.sources = [
                { src: $sce.trustAsResourceUrl(vm.media.contentPages[vm.media.page - 1].content), type: "video/mp4" }
            ];
        }

        // Paging supporting functions
        function goToPage() {
            if (isNaN(vm.pageNumber) || vm.pageNumber < 1 || vm.pageNumber > vm.media.pages) vm.pageNumber = vm.media.page;
            else vm.media.page = vm.pageNumber;
        }

        function firstPage() {
            vm.media.page = 1;
            setCurrentVideoBasedOnPage();
        }

        function lastPage() {
            vm.media.page = vm.media.pages;
            setCurrentVideoBasedOnPage();
        }

        function nextPage() {
            vm.media.page++;
            if (vm.media.page > vm.media.pages) vm.media.page = 1;
            setCurrentVideoBasedOnPage();
        }

        function previousPage() {
            vm.media.page--;
            if (vm.media.page < 1) vm.media.page = vm.media.pages;
            setCurrentVideoBasedOnPage();
        }

        function toggleMediaDetailsPanel() {
            $('#mediaDetails').collapse("toggle");
            vm.mediaDetailsPanelIsVisible = !vm.mediaDetailsPanelIsVisible;
        }
    }
})();