define(['plugins/http', 'durandal/app', 'knockout'], function (http, app, ko) {
    //Note: This module exports an object.
    //That means that every module that "requires" it will get the same object instance.
    //If you wish to be able to create multiple instances, instead export a function.
    //See the "welcome" module for an example of function export.
    var that;

    return {
        displayName: 'Product Test',
        description: 'In this test we get products from the DB and we have the possibility to get extra details (In Progress)',
        products: ko.observableArray([]),
        GetAll: function () {
            $.getJSON("http://localhost:/back.empire/api/product", {},
            function (data) {
                that.products(data);
            });
        },
        activate: function () {
            that = this;

            //return http.jsonp('http://api.flickr.com/services/feeds/photos_public.gne', { tags: 'Nujabes', tagmode: 'any', format: 'json' }, 'jsoncallback').then(function(response) {
            //    that.images(response.items);
            //});
        },
        select: function(item) {
            //the app model allows easy display of modal dialogs by passing a view model
            //views are usually located by convention, but you an specify it as well with viewUrl
            item.viewUrl = 'views/detail';
            app.showDialog(item);
        },
        canDeactivate: function () {
            //the router's activator calls this function to see if it can leave the screen
            return app.showMessage('Are you sure you want to leave this page?', 'Navigate', ['Yes', 'No']);
        }
    };
});