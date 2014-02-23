define(['app/app'],
    function(app) {
        app.controller('offersGridController', [
            '$scope',
            '$resource',
            function ($scope, $resource) {
                
                var Offers = $resource('http://localhost:52282/api/Offers');
                
                $scope.greet = "Welcome to the offers grid";
                $scope.filteringText = '';
                $scope.offersData = [];
                $scope.mySelections = [];
                $scope.offersGrid =
                       {
                           data: 'offersData',
                           multiSelect: false,
                           selectedItems: $scope.mySelections,
                           columnDefs: [
                               { field: 'customer', displayName: 'Customer' },
                               { field: 'offerType', displayName: 'Type' },
                               { field: 'createdOn', displayName: 'Created on', cellFilter: 'date' },
                               { field: 'followedOn', displayName: 'Followed on', cellFilter: 'date' },
                               { field: 'offerStatus', displayName: 'Status' },
                               { field: 'successAmount', displayName: 'Success' },
                               { field: 'priceAmount', displayName: 'Price', cellFilter: 'currency' }
                           ]
                       };
                $scope.offersData = Offers.query();
            }
        ]);
    }
);