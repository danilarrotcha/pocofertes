POC Ofertes
==========

Prove of Concept for Ofertes project
------------------------------------

This is a project that will try to show how to work together within an:
1. ASP.NET MVC 5 site
2. Web API
3. Entity framework 6
4. Angular JS.

There are some frameworks used for the cause:
1. Generic Repository and UoW framework:
This is used to simplify the BL and DAL layers. This framework provides the UoW and generic repository pattern in play.
You can find more information concerning it at:
http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/
and at:
http://genericunitofworkandrepositories.codeplex.com/releases/view/113204

2. RequireJS
This javascript AMD allow as to modularize our javascript layer.
It will also provide us the ability to lazy loading angular js controllers following the concept of Ifeanyi Isitor.
Please, don't save time and go straigh to his blog's page to read more about this topic:
http://ify.io/lazy-loading-in-angularjs/

3. Twitter bootstrap
4. Angular UI bootstrap and NgGrid:
http://angular-ui.github.io/

The main overview:
Nowadays, ASP.NET MVC X and Wep API provides a well known platform for building enterprise web applications. 
Personally, I do believe in the power of AngularJS and I was wondering how to mix up this tecnologies and have best of
both.
This poc's main objective is to try to use the following features:
1. AngularJS as an inside SPA of an hypothetical ASP.NET corp site. This is in our case, an Area.
2. Using AngularJS lazy loaded in order to win on performance.
3. Using requirejs to modularize our js layer.
4. Using Karma to realize TDD and E2E tests.
5. Using ASP.NET MVC to provide a robust and complete web application that could contain many SPA's, using different frameworks such as AngularJS, knokout and so on.
6. Using ASP.NET Wep API to expose data and OData ( using new features of .net 4.5 such as async/await)
7. Using Entity framework 6 as ORM (also using async and await new features).
8. Using a unit testing framework also for the backend code, in this case, xunit.

Instructions:
1. Download NodeJS, http://nodejs.org/
2. install KARMA via NPM from node console: npm install -g karma
3. Download the source code for this POC.
4. Seed the database, with the help of the Offers.Data.Initializer project in this source. Make sure you set the proper connection string at the app.config file found in the same project.
   Run the test 'OffersDbInitializer'.
5. You will then be ready to launch the web application.

If you would like to see the angular SPA go to Offers Area.
If you would like to see in play the OData service go to http://localhost:52282/odata/OffersQuery route and execute any supported commands ($filter, $orderby, $top and $skip).
Samples are:
* http://localhost:52282/odata/OffersQuery?$orderby=PriceAmount%20desc
* http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2030
* http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2035
* http://localhost:52282/odata/OffersQuery?$filter=PriceAmount%20gt%201500&$top=10
* http://localhost:52282/odata/OffersQuery?$filter=PriceAmount%20lt%201000or%20PriceAmount%20eq%202100

Have fun!

