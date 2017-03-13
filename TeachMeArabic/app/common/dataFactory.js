angular.module('app')
    .factory('dataFactory', ['$http', function ($http) {

        var bookUrlBase = '/api/book';
        var dataFactory = {};

        // Login
        // Student login
        dataFactory.checkStudentLogin = function(login) {
            return $http.post('/api/studentLogin', login);
        }

        // BookTypes
        dataFactory.getBookTypes = function () {
            return $http.get('/api/bookTypes');
        };

        // Languages
        dataFactory.getLanguages = function () {
            return $http.get('/api/languages');
        };

        // Books
        dataFactory.getBooks = function (search) {
            return $http.get(bookUrlBase);
        };

        dataFactory.getBook = function (id) {
            return $http.get(bookUrlBase + '/' + id);
        };

        dataFactory.insertBook = function (book) {
            return $http.post(bookUrlBase, book);
        };

        dataFactory.updateBook = function (book) {
            return $http.put(bookUrlBase + '/' + book.id, book);
        };

        dataFactory.search = function (search) {
            return $http.post(bookUrlBase, search);
        };

        dataFactory.deleteBook = function (id) {
            return $http.delete(bookUrlBase + '/' + id);
        };

        // Authors
        dataFactory.getAuthor = function (id) {
            return $http.get("/api/author/" + id);
        };

        return dataFactory;
    }]);
