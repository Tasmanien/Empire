define(['plugins/http', 'durandal/app', 'knockout'], function (http, app, ko) {
    //Note: This module exports an object.
    //That means that every module that "requires" it will get the same object instance.
    //If you wish to be able to create multiple instances, instead export a function.
    //See the "welcome" module for an example of function export.

    var baseProductURI = "http://localhost:64231/api/product";

    function test(id) {
        var valeur = "#loading_" + id + ", #descriptionButton_" + id;
        $(valeur).toggle();
    };

    function ProductModel(id, name, desc) {
        var self = this;

        self.id = ko.observable(id);
        self.name = ko.observable(name);
        self.description = ko.observable(desc);

        self.getDescription = function () {
            var uri = baseProductURI + '/description/' + self.id();

            test(self.id());

            $.ajax({
                url: uri,
                type: "GET",
                dataType: 'json',
                success: function (data) {
                    self.description(data.Description);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("GetDescription Status: " + textStatus);
                    alert("GetDescription Error: " + errorThrown);
                }
            });
        }
    };

    return {
        displayName: 'Product Test',
        flickrDesc: "Here we use the flickr's api to obtain picture",
        description: 'In this test we get products from the DB and we have the possibility to get extra details (In Progress)',
        images: ko.observableArray([]),
        products: ko.observableArray([]),
        getProducts: function () {
            var uri = baseProductURI;

            var that = this;

            $.ajax({
                url: uri,
                type: "GET",
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (index, value) {
                        var prod = new ProductModel(value.Id, value.Name);
                        that.products.push(prod);
                    });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Product Status: " + textStatus);
                    alert("Product Error: " + errorThrown);
                }
            });
        },
        activate: function () {
        },
        getImages: function () {
            var that = this;

            return http.jsonp('http://api.flickr.com/services/feeds/photos_public.gne', { tags: 'luxury', tagmode: 'any', format: 'json' }, 'jsoncallback').then(function (response) {
                that.images(response.items);
            });
        },
        select: function(item) {
            //the app model allows easy display of modal dialogs by passing a view model
            //views are usually located by convention, but you an specify it as well with viewUrl
            item.viewUrl = 'views/detail';
            app.showDialog(item);
        }
    };
});