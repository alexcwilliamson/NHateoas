'use strict';
nhateoasSampleApp.controller('MainMenuController',
    function MainMenuController($scope, $location) {
        $scope.start = function () {
            $location.replace();
            $location.url('/');
        };
    });