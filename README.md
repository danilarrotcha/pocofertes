#Prove of Concept for Ofertes project

This is a project that will try to show how to work together within an:
* ASP.NET MVC 5 site
* Web API
* Entity framework 6
* Angular JS.

The background story:
Provide a full corporate web application, lets say, for a company that offers many services such as:
- Payroll processing
- Client office management services
- etc..

All in one, can be accomplish building a corp web application that could contain SPA's isolated.
In this early example, will contain an Area for Offers. Offers will be a SPA build on top of angularJS.
This SPA will try to still use the MVC server part to easily manage authorization and visibility at server side. So templates for angular js will become first ASP.Net views. The data providers will be in fact the Wep API Controllers, both api and odata controllers.

# Table of Contents
 
* [Frameworks used](#frameworks-used)
* [Overview](#overview)
* [Other points of interests] (#other)
* [Contact me] (#contact-me)

# <a name="frameworks-used"></a>Frameworks used for the cause
* Generic Repository and UoW framework:
This is used to simplify the BL and DAL layers. This framework provides the UoW and generic repository pattern in play.
You can find more information concerning it at [Long Le's Blog](http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/) and at [codeplex site](http://genericunitofworkandrepositories.codeplex.com/releases/view/113204).

* RequireJS
This javascript AMD allow as to modularize our javascript layer.
It will also provide us the ability to lazy loading angular js controllers following the concept of **Ifeanyi Isitor**.
Please, don't save time and go straigh to his [blog's page](http://ify.io/lazy-loading-in-angularjs/) to read more about this topic.

* [Twitter bootstrap](http://getbootstrap.com/2.3.2/)
* [Angular UI bootstrap and NgGrid](http://angular-ui.github.io/)
* [ASP.NET MVC 5](http://www.asp.net/vnext/overview/aspnet-mvc)
* Web API via nuget
* [xUnit](http://xunit.codeplex.com/)
* [Entity framework 6](https://entityframework.codeplex.com/wikipage?title=specs)
* [Karma](http://karma-runner.github.io/0.10/index.html), to realize tdd and e2e tests for the js layer:
  (will require nodejs installed) 
* [Karma-html-reporter](https://www.npmjs.org/package/karma-html-reporter), to produce html files as output for the tests results.

# <a name="overview"></a>Main overview:
Nowadays, ASP.NET MVC X and Wep API provides a well known platform for building enterprise web applications. 
Personally, I do believe in the power of AngularJS and I was wondering how to mix up this tecnologies and have best of
both.
This poc's main objective is to try to use the following features:
* AngularJS as an inside SPA of an hypothetical ASP.NET corp site. This is in our case, an Area.
* Using AngularJS lazy loaded in order to win on performance.
* Using requirejs to modularize our js layer.
* Using Karma to realize TDD and E2E tests.
* Using ASP.NET MVC to provide a robust and complete web application that could contain many SPA's, using different frameworks such as AngularJS, knokout and so on.
* Using ASP.NET Wep API to expose data and OData ( using new features of .net 4.5 such as async/await)
* Using Entity framework 6 as ORM (also using async and await new features).
* Using a unit testing framework also for the backend code, in this case, xunit.

# <a name="instructions"></a>Instructions:
* Download NodeJS, http://nodejs.org/
* Install KARMA via NPM from node console: **npm install -g karma**
* Install KARMA-HTML-REPORTER via NPM from node console: **npm install karma-html-reporter --global**
* Download the source code for this POC.
* Seed the database, with the help of the **Offers.Data.Initializer** project in this source. Make sure you set the proper connection string at the **app.config** file found in the same project.
   Run the test **'OffersDbInitializer'**.
* You will then be ready to launch the web application.
* If you like to run karma and see how fun tests go, just open the command line and locate your self into the project Offers area and run karma command: *karma start*

# <a name="other"></a> Other points of interests:
If you would like to see the angular SPA go to Offers Area.
If you would like to see in play the OData service go to **http://localhost:52282/odata/OffersQuery** route and execute any supported commands ($filter, $orderby, $top and $skip).
Samples are:
- *http://localhost:52282/odata/OffersQuery?$orderby=PriceAmount%20desc*
- *http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2030*
- *http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2035*
- *http://localhost:52282/odata/OffersQuery?$filter=PriceAmount%20gt%201500&$top=10*
- *http://localhost:52282/odata/OffersQuery?$filter=PriceAmount%20lt%201000or%20PriceAmount%20eq%202100*

If you would like to see the OfferController async api version go to:
- **http://localhost:52282/api/Offers**

# <a name="contact-me"></a>Contact me at:
*daniel.larrotcha@gmail.com*

Have fun!

