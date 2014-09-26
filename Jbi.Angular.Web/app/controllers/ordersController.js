'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    var vm = this;

    $scope.orders = [];

    $scope.delete = function (order)
    {
        console.log('delete', order);

        ordersService.deleteOrder(order.orderID).then(function (results) {
            vm.getOrders();
        });
    }

    $scope.add = function () {
        var newOrder = $scope.neworder;

        ordersService.addOrder(newOrder).then(function (results) {
            vm.getOrders();
        });
    }

    $scope.edit = function (order) {
        $scope.neworder = order;
    }

    $scope.editSave = function (order) {
        $scope.neworder = order;
    }

    vm.getOrders = function () {
        ordersService.getOrders().then(function (results) {

            $scope.orders = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }


    vm.getOrders();

}]);