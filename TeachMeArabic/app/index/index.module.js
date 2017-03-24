(function() {
    'use strict';
    angular.module('app',
        [
            'ngRoute',
            'ngSanitize',
            'ui.bootstrap.pagination',
            'com.2fdevs.videogular',
			'com.2fdevs.videogular.plugins.controls',
			'com.2fdevs.videogular.plugins.overlayplay',
			'com.2fdevs.videogular.plugins.poster',
			'com.2fdevs.videogular.plugins.buffering'

        ]);
})();