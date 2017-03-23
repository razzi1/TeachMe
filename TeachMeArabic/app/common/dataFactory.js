angular.module('app')
    .factory('dataFactory', ['$http', function ($http) {

        var mediaUrlBase = '/api/media';
        var dataFactory = {};

        // Login
        // Student login
        dataFactory.checkStudentLogin = function(login) {
            return $http.post('/api/studentLogin', login);
        }

        // Media Categories
        dataFactory.getMediaCategories = function () {
            return $http.get('/api/mediaCategories');
        };

        // Languages
        dataFactory.getLanguages = function () {
            return $http.get('/api/languages');
        };

        // Media

        dataFactory.getMediaPage = function (search) {
            return $http.post(mediaUrlBase, search);
        };

        dataFactory.getMediaCount = function (search) {
            return $http.post(mediaUrlBase, search);
        };

        dataFactory.getMedia = function (id) {
            return $http.get(mediaUrlBase + '/' + id);
        };

        dataFactory.insertMedia = function (media) {
            return $http.post(mediaUrlBase, media);
        };

        dataFactory.updateMedia = function (media) {
            return $http.put(mediaUrlBase + '/' + media.id, media);
        };

        dataFactory.deleteMedia = function (id) {
            return $http.delete(mediaUrlBase + '/' + id);
        };

        // Authors
        dataFactory.getAuthor = function (id) {
            return $http.get("/api/author/" + id);
        };

        return dataFactory;
    }]);
