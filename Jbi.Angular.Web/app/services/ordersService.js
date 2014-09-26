'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    var _getOrders = function () {

        return $http.get(serviceBase + 'api/orders').then(function (results) {
            return results;
        });
    };

    var _deleteOrder = function (id) {

        return $http.delete(serviceBase + 'api/orders/'+ id).then(function (results) {
            return results;
        });
    };

    var _addOrder = function (model) {

        return $http.post(serviceBase + 'api/orders/Post', model).then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getOrders = _getOrders;
    ordersServiceFactory.deleteOrder = _deleteOrder;
    ordersServiceFactory.addOrder = _addOrder;

    return ordersServiceFactory;

}]);