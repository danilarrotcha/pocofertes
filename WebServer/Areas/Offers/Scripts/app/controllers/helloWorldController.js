﻿define(['app/app',
    'angular'],
    function(app) {
        app.controller('helloWorldController', [
            '$scope',
            function($scope) {
                $scope.greet = "Hello world!";
            }
        ]);
    }
);