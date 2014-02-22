define(['app/app', 'app/controllers/helloWorldController'], function (app, helloWorldController)
{
    describe('Check that my app module is being returned and loaded', function () {
        var offersApp = app;

        it('app module is loaded', function () {
            expect(offersApp).toEqual(app);
        });
    });
    
    describe('helloWolrdController should:', function () {

        var scope,
            mocking = angular.mock;
 
        //mock Application to allow us to inject our own dependencies
        beforeEach(mocking.module('offersApp'));
        //mock the controller for the same reason and include $rootScope and $controller
        beforeEach(mocking.inject(function ($rootScope, $controller) {
            //create an empty scope
            scope = $rootScope.$new();
            //declare the controller and inject our empty scope
            $controller('helloWorldController', {$scope: scope});
        }));

        it('return the proper greet', function () {
            expect(scope.greet).toEqual('Hello world!');
        });
    });
});