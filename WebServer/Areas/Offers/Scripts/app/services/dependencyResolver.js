/*
* This is a dependency resovler to provide angular app lazy loading.
* Currenty, this is not supported out of the box inside angularJS
* Reference code: 
*   http://ify.io/lazy-loading-in-angularjs/
*/

define(['angular'], function () {
    return function(dependencies) {
        var definition =
        {
            resolver: ['$q', '$rootScope', function($q, $rootScope) {
                var deferred = $q.defer();
                
                require(dependencies, function() {
                    $rootScope.$apply(function() {
                        deferred.resolve();
                    });
                });

                return deferred.promise;
            }]
        };

        return definition;
    };
});