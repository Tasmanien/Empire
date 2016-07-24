define(function() {
    var ctor = function () {
        this.displayName = 'Welcome to the first test project on which the Empire will be build upon!';
        this.description = 'Let\'s grind';
        this.features = [
            'Durandal js',
            'Required js',
            'knockout',
            'jquery'
        ];
    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return ctor;
});