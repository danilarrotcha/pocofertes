// Karma configuration
// Generated on Tue Feb 18 2014 23:15:46 GMT+0000 (GMT Standard Time)

module.exports = function(config) {
  config.set({

    // base path, that will be used to resolve files and exclude
    basePath: '',


    // frameworks to use
    frameworks: ['jasmine', 'requirejs'],


    // list of files / patterns to load in the browser
    files: [
      {pattern: 'Scripts/*.js', included: false},
      { pattern: 'Scripts/**/*.js', included: false },
      { pattern: 'libs/angular.js', included: true },
        { pattern: 'libs/angular-route.js', included: false },
        { pattern: 'libs/angular-resource.js', included: false },
        { pattern: 'libs/angular-mocks.js', included: true },
        { pattern: 'libs/jquery.js', included: true },
        { pattern: 'libs/ng-grid.js', included: true },
      //{ pattern: 'tests/*.js', included: false },
      //{pattern: 'tests/e2e/*.js', included: false},
      { pattern: 'tests/specs/*Spec.js', included: false },
        //'libs/angular-mocks.js',
        'tests/test-main.js'
    ],


    // list of files to exclude
    exclude: [
      
    ],


    // test results reporter to use
    // possible values: 'dots', 'progress', 'junit', 'growl', 'coverage'
    reporters: ['progress', 'html'],
    
      // the default configuration
    htmlReporter: {
        outputDir: 'karma_html',
        templatePath: __dirname+'/tests/jasmine_template.html'
    },


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // Start these browsers, currently available:
    // - Chrome
    // - ChromeCanary
    // - Firefox
    // - Opera (has to be installed with `npm install karma-opera-launcher`)
    // - Safari (only Mac; has to be installed with `npm install karma-safari-launcher`)
    // - PhantomJS
    // - IE (only Windows; has to be installed with `npm install karma-ie-launcher`)
    browsers: ['Chrome'],


    // If browser does not capture in given timeout [ms], kill it
    captureTimeout: 60000,


    // Continuous Integration mode
    // if true, it capture browsers, run tests and exit
    singleRun: false
  });
};
