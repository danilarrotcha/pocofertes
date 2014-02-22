define(['app/app'],
    function(app) {
        app.controller('helloWorldController', [
            '$scope',
            function ($scope) {
                $scope.greet = "Hello world!";
            }
        ]);
    }
);