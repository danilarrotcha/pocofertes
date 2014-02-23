define(['app/app'],
    function (app) {
        app.controller('offersOverviewController', [
            '$scope',
            function ($scope) {
                var accepted = [],
                    pendingToAccept = [],
                    refused = [],
                    pendingToValidate = [],
                    validated = [],
                    totalOffers = 0;

                $scope
                    .offersData
                    .$promise
                    .then(function(data) {
                        totalOffers = data.length;
                        accepted = data.filter(function(offer) { return offer.offerStatusId === 3; });
                        pendingToAccept = data.filter(function(offer) { return offer.offerStatusId === 2; });
                        refused = data.filter(function(offer) { return offer.offerStatusId === 4; });
                        pendingToValidate = data.filter(function(offer) { return offer.offerStatusId === 0; });
                        validated = data.filter(function(offer) { return offer.offerStatusId === 1; });

                        $scope.acceptedOffers = accepted.length;
                        $scope.pendingToAccept = pendingToAccept.length;
                        $scope.refused = refused.length;
                        $scope.pendingToValidate = pendingToValidate.length;
                        $scope.validated = validated.length;

                        $scope.acceptedOffersAmount = getTotalAmount(accepted);
                        $scope.pendingToAcceptAmount = getTotalAmount(pendingToAccept);
                        $scope.refusedAmount = getTotalAmount(refused);
                        $scope.pendingToValidateAmount = getTotalAmount(pendingToValidate);
                        $scope.validatedAmount = getTotalAmount(validated);
                        $scope.totalAmount =
                            $scope.acceptedOffersAmount + $scope.pendingToAcceptAmount +
                                $scope.refusedAmount + $scope.pendingToValidateAmount +
                                $scope.validatedAmount;

                        $scope.totalOffers = totalOffers;
                        $scope.acceptedOffersPc = Math.round(($scope.acceptedOffersAmount / $scope.totalAmount) * 100);
                        $scope.pendingToAcceptPc = Math.round(($scope.pendingToAcceptAmount / $scope.totalAmount) * 100);
                        $scope.refusedPc = Math.round(($scope.refusedAmount / $scope.totalAmount) * 100);
                        $scope.pendingToValidatePc = Math.round(($scope.pendingToValidateAmount / $scope.totalAmount) * 100);
                        $scope.validatedPc = Math.round(($scope.validatedAmount / $scope.totalAmount) * 100);

                    }, function(error) {
                        console.warn(error);
                    });
                
                function getTotalAmount(inArray) {
                    var total = 0;
                    inArray.forEach(function(offer) {
                        total += offer.priceAmount;
                    });
                    return total;
                }

            }
        ]);
    }
);