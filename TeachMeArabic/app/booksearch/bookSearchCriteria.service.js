(function () {
	'use strict';

	angular.module('app').factory("searchCriteria", function () {
	    return {
	        alreadySearched: false,
			selectedBookType: null,
			selectedLanguage: null,
			title: null,
			author: null,
			keywords: null
		}
	});
})();