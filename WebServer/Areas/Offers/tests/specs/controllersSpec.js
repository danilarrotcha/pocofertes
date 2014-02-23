define(['app/app', 'app/controllers/offersGridController'], function (app, offersGridController)
{
    // todo: mirar http://www.tuesdaydeveloper.com/2013/06/angularjs-testing-with-karma-and-jasmine/
    describe('Check that my app module is being returned and loaded', function () {
        var offersApp = app;

        it('app module is loaded', function () {
            expect(offersApp).toEqual(app);
        });
    });
    
    describe('offersGridController', function(){
        var scope, $httpBackend;
 
        //mock Application to allow us to inject our own dependencies
        beforeEach(angular.mock.module('offersApp'));

        //mock the controller for the same reason and include $rootScope and $controller
        beforeEach(angular.mock.inject(function($rootScope, $controller, _$httpBackend_){
            $httpBackend = _$httpBackend_;
            $httpBackend
                .when('GET', 'http://localhost:52282/api/Offers')
                .respond([
                    { customer: 'Bob' },
                    { customer: 'Jane' }]);
 
            //create an empty scope
            scope = $rootScope.$new();
            //declare the controller and inject our empty scope
            $controller('offersGridController', { $scope: scope });
        }));
        // tests start here
        it('should have variable text = "Welcome to the offers grid"', function () {
            expect(scope.greet).toBe('Welcome to the offers grid');
        });
        it('should fetch list of offers', function(){
            $httpBackend.flush();
            expect(scope.offersData.length).toBe(2);
            expect(scope.offersData[0].customer).toBe('Bob');
        });
    });
});